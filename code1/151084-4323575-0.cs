    using System.Collections.Generic;
    using System.Concurrency;
    using Moq;
    using NUnit.Framework;
    
    namespace StackOverflowScratchPad
    {
        public interface IBar
        {
            void Start(IEnumerable<IFoo> foos);
        }
    
        public interface IFoo
        {
            void Start();
        }
    
        public class Bar : IBar
        {
            private readonly IScheduler _scheduler;
    
            public Bar(IScheduler scheduler)
            {
                _scheduler = scheduler;
            }
    
            public void Start(IEnumerable<IFoo> foos)
            {
                foreach (var foo in foos)
                {
                    var foo1 = foo;  //Save to local copy, as to not access modified closure.
                    _scheduler.Schedule(foo1.Start);
                }
            }
        }
    
        [TestFixture]
        public class MyTestClass
        {
            [Test]
            public void StartBar_ShouldCallStartOnAllFoo_WhenFoosExist()
            {
                //ARRANGE
                TestScheduler scheduler = new TestScheduler();
                IBar sutBar = new Bar(scheduler);
    
                //Create a foo, and setup expectation
                var mockFoo0 = new Mock<IFoo>();
                mockFoo0.Setup(foo => foo.Start());
    
                var mockFoo1 = new Mock<IFoo>();
                mockFoo1.Setup(foo => foo.Start());
    
                //Add mockobjects to a collection
                var foos = new List<IFoo>
                           {
                               mockFoo0.Object,
                               mockFoo1.Object
                           };
    
                //ACT
                sutBar.Start(foos); //Should call mockFoo.Start()
                scheduler.Run();
    
                //ASSERT
                mockFoo0.VerifyAll();
                mockFoo1.VerifyAll();
            }
        }
    }
