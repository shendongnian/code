    public interface IWidget
    {
        void Behave();
        IWidget Parent { get; }
    }
    public class AWidget : IWidget
    {
        IWidget IWidget.Parent { get { return this.Parent; } }
        void IWidget.Behave() { this.Slap(); }
        public BWidget Parent { get; set; }
        public void Slap() { Console.WriteLine("AWidget is slapped!"); }
    }
    public class BWidget : IWidget
    {
        IWidget IWidget.Parent { get { return this.Parent; } }
        void IWidget.Behave() { this.Pay(); }
        public AWidget Parent { get; set; }
        public void Pay() { Console.WriteLine("BWidget is paid!"); }
    }
    public class WidgetTester
    {
        public void AWidgetTestThroughIWidget()
        {
            IWidget myWidget = new AWidget() { Parent = new BWidget() };
            myWidget.Behave();
            myWidget.Parent.Behave();
        }
        public void AWidgetTest()
        {
            AWidget myWidget = new AWidget() { Parent = new BWidget() };
            myWidget.Slap();
            myWidget.Parent.Pay();
        }
        public void BWidgetTestThroughIWidget()
        {
            IWidget myOtherWidget = new BWidget() { Parent = new AWidget() };
            myOtherWidget.Behave();
            myOtherWidget.Parent.Behave();
        }
        public void BWidgetTest()
        {
            BWidget myOtherWidget = new BWidget() { Parent = new AWidget() };
            myOtherWidget.Pay();
            myOtherWidget.Parent.Slap();
        }
    }
