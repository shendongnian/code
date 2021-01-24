    class RichTextBoxAppend
    {
        public static void AddNewText(string message, Form1 f)
        {
             f.RichText.AppendText(DateTime.Now.ToString() + ": " + message + "\r\n");
         }
    }
    
    public class SomeClass
    {
        public void SomeMethod(Form1 form)
        {
            //Some stuff happens here
            RichTextBoxAppend.AddNewText("Some message", form);
        }
    }
