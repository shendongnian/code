    public class ClassUnderTest
    {
        private static Func<string, string, MessageBoxButtons, DialogResult>
           _messageBoxLocator = MessageBox.Show;
        public static Func<string, string, MessageBoxButtons, DialogResult> 
           MessageBoxDependency
        {
            get { return _messageBoxLocator; }
            set { _messageBoxLocator = value; }
        } 
        private void MyMethodOld(object sender, EventArgs e)
        {
            if (MessageBox.Show("test", "", MessageBoxButtons.YesNo) == 
                System.Windows.Forms.DialogResult.Yes)
            {
                //Yes code
                AnsweredYes = true;
            }
            else
            {
                //No code
            }
        }
        public bool AnsweredYes = false;
        public void MyMethod(object sender, EventArgs e)
        {
            if (MessageBoxDependency(
                        "testText", "testCaption", MessageBoxButtons.YesNo) 
                ==
                System.Windows.Forms.DialogResult.Yes)
            {
                //proceed code
                AnsweredYes = true;
            }
            else
            {
                //abort code
            }
        }
    }
