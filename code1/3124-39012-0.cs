    public class MyTextBox : TextBox
    {
        public override string ClientID { get { return ID; } }
        public override string UniqueID { get { return ID; } }
    }
