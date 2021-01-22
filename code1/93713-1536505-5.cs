    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
           
        public void Save()
        {
            //Create a canvas object
            CCanvas Canvas1 = new CCanvas();
            //Add controls
            Canvas1.AddControls(new CDrawing(CDrawing.ControlTypes.Label, "This is text on a label1", 10, 100, "Tahoma", 7.5, "Regular", -778225617));
            Canvas1.AddControls(new CDrawing(CDrawing.ControlTypes.Label, "This is text on a label11", 20, 200, "Verdana", 7.5, "Regular", -778225617));
            Canvas1.AddControls(new CDrawing(CDrawing.ControlTypes.Label, "This is text on a label111", 30, 300, "Times New Roman", 7.5, "Regular", -778225617));
            //Save the object
            Canvas1.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Load();
        }
        public void Load()
        {
            //Retrieve
            CCanvas Canvas2 = new CCanvas();
            //opens the binary file
            Canvas2 = Canvas2.Open();
            //loads control to this form.
            Canvas2.ReloadControl(this);
          
        }
    }
