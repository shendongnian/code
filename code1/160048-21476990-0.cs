    **using Word = Microsoft.Office.Interop.Word;**
    
    Notice the "Word=", this is the secret to solving your pain. You must have Word installed, btw.
    
    Here's how I approach it, when I am not sure the user has Word installed:
    
    // 1. This code creates the word application, a first REQUIRED step in manipulating a Word file 
                Word.ApplicationClass wordApplication;
                try { wordApplication = new Word.ApplicationClass(); }
                catch (Exception e) { MessageBox.Show("ERROR! Do you have MS Word installed? " + e.Message.ToString()); }
