    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.Items.Add("foo.txt");
            this.listBox1.MouseDown += new MouseEventHandler(listBox1_MouseDown);
            this.listBox1.DragOver += new DragEventHandler(listBox1_DragOver);
        }
        void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            string[] filesToDrag = 
            {
                "c:/foo.txt"
            };
            this.listBox1.DoDragDrop(new DataObject(DataFormats.FileDrop, filesToDrag), DragDropEffects.Copy);
        }
    }
