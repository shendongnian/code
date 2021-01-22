     // interface for exposing append method
    public interface IAppend
    {
        void AppendText(string text);
    }
    // some class that can use the IAppend interface
    public class SomeOtherClass
    {
        private IAppend _appendTarget = null;
        public SomeOtherClass(IAppend appendTarget)
        {
            _appendTarget = appendTarget;
        }
        private void AppendText(string text)
        {
            if (_appendTarget != null)
            {
                _appendTarget.AppendText(text);
            }
        }
    }
    // implementation of IAppend in the form
    void IAppend.AppendText(string text)
    {
        textBox1.AppendText(text);
    }
