    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            var child = new Form2();
            child.TopLevel = false;
            child.Location = new Point(10, 5);
            child.Size = new Size(100, 100);
            child.BackColor = Color.Yellow;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Visible = true;
            this.Controls.Add(child);
        }
    }
