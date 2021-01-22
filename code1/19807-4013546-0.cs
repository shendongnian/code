    ...
    using System.Linq;
    ...
    
    public partial class Form1 : Form
    {
        MdiClient mdi_client;
        public Form1()
        {
            InitializeComponent();
            mdi_client = this.Controls.OfType<MdiClient>().FirstOrDefault();
            mdi_client.AllowDrop = true;
            mdi_client.DragEnter += Form1_DragEnter;
            mdi_client.DragDrop += Form1_DragDrop;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            myForm m = new myForm();
            m.Text = (string)e.Data.GetData(typeof(string));
            m.MdiParent = this;
            m.Show();
            m.Location = mdi_client.PointToClient(new Point(e.X, e.Y));
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
