    public partial class Form1
    {
        public Color customColor = Color.Red;
    
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer(Form1 form) : base(new MyColors(form)) { }
        }
    
        private class MyColors : ProfessionalColorTable
        {
            Form1 _form;
            public MyColors(Form1 form)
            {
                _form = form;
            }
            public override Color MenuItemSelected
            {
                get { return _form.customColor; }
            }
        }
    }
