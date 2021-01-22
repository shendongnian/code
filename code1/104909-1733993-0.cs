      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          label1.MouseDown += new MouseEventHandler(label1_MouseDown);
          textBox1.AllowDrop = true;
          textBox1.DragEnter += new DragEventHandler(textBox1_DragEnter);
          textBox1.DragDrop += new DragEventHandler(textBox1_DragDrop);
        }
    
        void label1_MouseDown(object sender, MouseEventArgs e) {
          DoDragDrop(label1.Text, DragDropEffects.Copy);
        }
        void textBox1_DragEnter(object sender, DragEventArgs e) {
          if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
        }
        void textBox1_DragDrop(object sender, DragEventArgs e) {
          textBox1.Text = (string)e.Data.GetData(DataFormats.Text);
        }
      }
