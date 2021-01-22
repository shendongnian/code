    interface IMyFormFlag
    {
        bool IsChecked { get; }
    }
    
    public class MyForm : Form, IMyFormFlag
    {
        CheckBox chkMyFlag;
    
        bool IsChecked { get { return chkMyFlag.Checked; } }
    }
    
    public class MyObject
    {
        public void DoSomethingImportant(IMyFormFlag formFlag)
        {
            if (formFlag.IsChecked)
            {
                // do something here
            }
        }
    }
