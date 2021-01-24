    public interface IMessageBoxService
    {
        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
    class DefaultMessageBoxService : IMessageBoxService
    {
        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
    public class MyForm
    {
        IMessageBoxService _messageBoxService; // use some IoC mechanism to set this
        public void validation()
        {
            if (...)
            {
                _messageBoxService.ShowMessageBox("enter your name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
