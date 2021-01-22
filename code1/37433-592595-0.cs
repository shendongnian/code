    using System.Collections.Generic;
    
    namespace Tests
    {
        public interface IView
        {
            List<string> Names { get; set; }
        }
    
        public class Presenter
        {
            public List<string> GetNames(IView view)
            {
                return view.Names;
            }
        }
    }
    
    using System.Collections.Generic;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    namespace Tests
    {
    
        [TestFixture]
        public class TestFixture
        {
            [Test]
            public void TestForStackOverflow()
            {
                var mockView = MockRepository.GenerateMock<IView>();
                var presenter = new Presenter();
                var names = new List<string> {"Test", "Test1"};
    
                mockView.Expect(v => v.Names).Return(names);
    
                Assert.AreEqual(names, presenter.GetNames(mockView));
            }
        }
    }
