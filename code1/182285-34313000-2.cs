        private static DialogResult ShowMessageBox(
            string message, 
            string caption, 
            MessageBoxButtons buttons, 
            MessageBoxIcon icon)
        {
            var showMessageBoxTask = new Task<DialogResult>(() =>
            {
                var form = new Form() {TopMost = true};
                var result = MessageBox.Show(
                    form,
                    PrepareMessage(message),
                    caption,
                    buttons,
                    icon);
                form.Dispose();
                return result;
            });
            showMessageBoxTask.Start();
            while (!showMessageBoxTask.IsCompleted && !showMessageBoxTask.IsFaulted)
            {
                Application.DoEvents();
            }
            return showMessageBoxTask.Result;
        }
