    public class SharedFunctionality
    {
        public void ImportantToCallThisOnLoad();
    }
    public class MyForm : Form
    {
        SharedFunctionality mySharedFunctionality = new SharedFunctionality();
        public void OnLoad()
        {
            mySharedFunctionality.ImportantToCallThisOnLoad();
        }
    }
    public class MyControl : Control
    {
        SharedFunctionality mySharedFunctionality = new SharedFunctionality();
        public void OnLoad()
        {
            mySharedFunctionality.ImportantToCallThisOnLoad();
        }
    }
