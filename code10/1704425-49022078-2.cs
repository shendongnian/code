    internal static class Util
        {
            internal static Func<string, string, string, MessageBoxButtons, MessageBoxIcon, DialogResult> MyMessageBoxFunc =
                    (handlerMessage, sourceProcess, messageBoxTitle, button, icon) =>
                    MessageBox.Show($"{handlerMessage} \n\n\"Source process = {sourceProcess}\"",
                                    $"{messageBoxTitle}",
                                    button,
                                    icon);
        }
