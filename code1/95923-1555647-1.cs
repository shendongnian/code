    public interface IControllerChild
    {
        public void Show();
        public bool Activate();
        public void Close();
        // add other behaviors here
    }
    
    public class DetailWindow : Window, IControllerChild 
    {
        // implement other behaviors here
    }
    
    public class MockControllerChild : IControllerChild
    {
        public void Show() { IsShowing = true; ActionLog.Add(MockControllerAction.Show); }
        public void Activate() { IsShowing = false; ActionLog.Add(MockControllerAction.Activate); }
        public void Close() { IsShowing = false; ActionLog.Add(MockControllerAction.Close); } 
        public bool IsShowing { get; private set; }
        public IList<MockControllerAction> ActionLog { get; private set; }
        // mock and record other behaviors here
    }
    
    public enum MockControllerAction 
    { 
        Show, 
        Activate, 
        Close,  
        // Add other behaviors here
    };
