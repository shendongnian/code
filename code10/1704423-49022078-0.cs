    Func<string, string, string, MessageBoxButtons, MessageBoxIcon, DialogResult> messageBoxFunc = 
                    (handlerMessage, sourceProcess, messageBoxTitle, button, icon) =>
    				MessageBox.Show($"{handlerMessage} \n\n\"Source process = {sourceProcess}\"",
                                    $"{messageBoxTitle}", 
                                    button,
                                    icon);
   
    //Calling above delegate
    messageBoxFunc("HanldlerTest1", 
                    "sourceprocessTest1", 
                    "Title1",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
