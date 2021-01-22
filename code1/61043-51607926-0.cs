    private void FormMain_Load(object sender, EventArgs e)
    {
        TheIncomingDataClass.SetupControl(textBox1);
    }
    
    public class TheIncomingDataClass
    {
        public static TextBox textbox = new TextBox();
        public static void SetupControl(TextBox txt)
        {
            textbox = txt;
        }
        public void IncomingMessage(string message)
        {
            textbox.Text = message;
        }
    }
