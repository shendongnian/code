      public partial class Form3 : Form
    {
        private int count = 1;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form2_Move(object sender, EventArgs e)
        {
            this.SaveFormSizeAndLocation();
        }
        protected override void OnShown(EventArgs e)
        {
            Text = Name;
            base.OnShown(e);
            this.LoadFormSizeAndLocation();
            this.Move += Form2_Move;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.SaveFormSizeAndLocation();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form3();
            frm.Name = "inner" + count.ToString();
            frm.Show();
            count++;
        }
    }
