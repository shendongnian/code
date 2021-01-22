    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddMyHardcodedAdditions();
        }
        void AddMyHardcodedAdditions()
        {
            TextBox tb = new TextBox();
            tb.Location = new Point(10, 10);
            Panel pn = new Panel();
            pn.Dock = DockStyle.Fill;
            pn.Controls.Add(tb);
            this.Controls.Add(pn);
        }
    }
