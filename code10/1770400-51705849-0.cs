    public class FormInputHandler
    {
        private Form1 _form1;
        public FormInputHandler(Form1 form1)
        {
            _form1 = form1;
            _form1.Controls["button1"].Click += Button1ClickHandler;
        }
        private void Button1ClickHandler(object sender, EventArgs e)
        {
            // Do stuff
        }
    }
