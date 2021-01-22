    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
        }
        [Serializable]
        class DragClass
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Collections.ArrayList aDragClasses = new System.Collections.ArrayList();
            aDragClasses.Add(new DragClass() { Prop1 = "Test1", Prop2 = 2 });
            aDragClasses.Add(new DragClass() { Prop1 = "Test2", Prop2 = 3 });
            aDragClasses.Add(new DragClass() { Prop1 = "Test3", Prop2 = 4 });
            
            DoDragDrop(aDragClasses, DragDropEffects.Copy);
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var aData in (System.Collections.IEnumerable)e.Data.GetData(typeof(System.Collections.ArrayList)))
            {
              System.Diagnostics.Debug.WriteLine(((DragClass)aData).Prop1);
            }
        }
    }
