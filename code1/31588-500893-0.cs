    public interface ISaveFileDialog
    {
        event CancelEventHandler FileOk;
    }
    public class SaveFileDialogStub : ISaveFileDialog
    {
        public event CancelEventHandler FileOk;
        public void RaiseFileOk(CancelEventArgs e)
        {
            FileOk(this, e);
        }
    }
    public class ClassUnderTest
    {
        public ClassUnderTest(ISaveFileDialog dialog)
        {
            dialog.FileOk += OnFileOk;
        }
        void OnFileOk(object sender, CancelEventArgs e)
        {
            //...
        }
    }
