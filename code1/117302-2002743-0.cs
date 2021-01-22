    using NUnit.Framework;
    using System.Windows.Forms;
    public interface IFoo
    {
        int Height { get; set; } // which is implemented by UserControl
    }
    
    public class SomeControl : UserControl, IFoo
    {
        public SomeControl()
        {
            Height = 123;
        }
    }
    
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void Test()
       {
           IFoo display = new SomeControl();
            
           Assert.IsTrue(display.Height == 123);
           display.Height = 789; 
           Assert.IsTrue(display.Height == 789);
       }
    }
