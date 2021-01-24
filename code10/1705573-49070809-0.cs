    public partial class Form1 : Form
    {
        public Form1()
        {
            Task.Factory.StartNew(() =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = "UI Change";
                }));
            });
            InitializeComponent();
        }
    }
