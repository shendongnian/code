    public partial class MyForm: Form
    {
        bool form_shown = false;
        private void MyForm_Load(object sender, EventArgs e)
        {
            form_shown = true;
        }
        private void pictureDummy_Paint(object sender, PaintEventArgs e)
        {
            if (form_shown)
            {
                MyOnShow();
                form_shown = false;    
            }
        }
    }
