    public class MyForm
    {
        private bool specialMode;
        public MyForm(bool mode)
        { 
            this.specialMode = mode;
        }
        private void newForm_Load(object sender, EventArgs e)
        {
            if (this.specialMode) 
            {
               //do some stuff here 
            }
            else
            {
               //Do something different
            }
        }
    }
