    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer holder;
        private System.Windows.Forms.Label say;
        public Form1()
        {
            InitializeComponent();
            say = new Label {Text = "start text"};
            Controls.Add(say);
            holder = new Timer {Interval = 5000};
            holder.Tick += HolderTick;
            holder.Enabled = true;
        }
        private void HolderTick(object sender, EventArgs e)
        {
            say.Text = "new after seconds";
            holder.Enabled = false;
        }
    }
