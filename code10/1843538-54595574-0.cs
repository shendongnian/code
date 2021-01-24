    public static class MessageBoxResult
    {
        public static int dialogResult;  // <== i use this value to determine what button was pressed
    }
    // your custom message box form code
    public partial class CustomMsgBox : Form
    {
        public CustomMsgBox()
        {
            InitializeComponent();
        }
        public void show(string pos0, string pos1, string pos2, string message)  //<=== initializing the message box with the values from your main code
        {
            button1.Text = pos0;
            button2.Text = pos1;
            button3.Text = pos2;
            label1.Text = message;
        }
     // message box events to set the static field incase a button on the custom form was changed
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxResult.dialogResult = 0;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxResult.dialogResult = 1;
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxResult.dialogResult = 2;
            this.Close();
        }
    }
    //usage
    {
        MessageBoxResult.dialogResult = -1;   // <== setting the static field to -1 to mean nothing was pressed
        CustomMsgBox cMsgBox = new CustomMsgBox();
        cMsgBox.show("your message");
        cMsgBox.ShowDialog();
    }
