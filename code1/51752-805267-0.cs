        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.listBox1.AllowDrop = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i <= 20; i++)
                {
                    this.listBox1.Items.Add(DateTime.Now.AddDays(i));
                }
            }
    
            private void listBox1_MouseDown(object sender, MouseEventArgs e)
            {
                this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
            }
    
            private void listBox1_DragOver(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Move;
            }
    
            private void listBox1_DragDrop(object sender, DragEventArgs e)
            {
                Point point = listBox1.PointToClient(new Point(e.X, e.Y));
                int index = this.listBox1.IndexFromPoint( point);
                object data = e.Data.GetData(typeof(DateTime));
                this.listBox1.Items.Remove(data);
                this.listBox1.Items.Insert(index, data);
                
            }
