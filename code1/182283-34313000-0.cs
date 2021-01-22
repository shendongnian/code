        private static DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var showMessageBoxTask = new Task<DialogResult>(() => MessageBox.Show(
                PrepareMessage(message),
                caption,
                buttons,
                icon
                ));
            showMessageBoxTask.Start();
            while (!showMessageBoxTask.IsCompleted || !showMessageBoxTask.IsFaulted)
            {
                Application.DoEvents();
            }
            return showMessageBoxTask.Result;
        }
