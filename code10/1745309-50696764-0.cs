    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int Method1(int i)
        {
            this.Invoke(new Action(() => { i++; }));
            return i;
        }
    }
