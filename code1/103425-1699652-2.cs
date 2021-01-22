    public partial class Form1: Form
    {
        public Form1()
        {
           InitializeComponent();
           this.MouseDown += Form1_MouseDown;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            string[] files = new string[] { @"C:\SomeTestFile.txt" };
            this.DoDragDrop(new DataObject(DataFormats.FileDrop, files),
              DragDropEffects.Copy);
        }
    } 
