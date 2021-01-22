    public partial class Form1 : Form
    {
        public SYSTEM_OUTPUT output;
        [DllImport("testeshm.dll", EntryPoint="getStatus")]
        public extern static int getStatus(out SYSTEM_OUTPUT output);
        public Form1()
        {
            InitializeComponent();           
        }
        private void ReadSharedMem_Click(object sender, EventArgs e)
        {
            try
            {
                if(getStatus(out output) != 0)
                {
                    //Do something about error.
                }
            }
            catch (AccessViolationException ave)
            {
                label1.Text = ave.Message;
            }
        }
    }
