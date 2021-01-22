    public partial class MyForm : Form
    {
        static int count = 0;
        public MyForm()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        public static void ShowMyDialog(MyForm form, IWin32Window owner)
        {
            count++;
            form.Text = "My ID: " + count;
            form.ShowDialog(owner);
        }
        delegate void MyDel(MyForm form, IWin32Window owner);
    
        private void MyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyDel del = ShowMyDialog;
            MyForm mySecondForm = new MyForm();
            this.Owner.BeginInvoke(del, mySecondForm, this.Owner);
        }
    }
