      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
          textBox1.AllowDrop = true;
          textBox1.DragEnter += new DragEventHandler(textBox1_DragEnter);
          textBox1.DragDrop += new DragEventHandler(textBox1_DragDrop);
    
        }
    
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
          if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
          else
            e.Effect = DragDropEffects.None; 
        }
    
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
          string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
    
    
        string s="";
        foreach (string File in FileList)
        s = s+ " "+ File ;
        textBox1.Text = s;
        }
      }
