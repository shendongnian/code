    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class ButtonVariables
        {
            public int value1 { get; set; }
            public int value2 { get; set; }
        }
        Dictionary<string, ButtonVariables> bv = new Dictionary<string, ButtonVariables>();
        private void ProcessClick(object sender)
        {
            ButtonVariables vars = GetVariables(sender);
            //Do stuff with your variable set here
        }
        private ButtonVariables GetVariables(object sender)
        {
            ButtonVariables returnValue = new ButtonVariables();
            switch (((Button)sender).Name.ToLower())
            {
                case "buttona":
                    return bv["A"];
                case "buttonb":
                    return bv["B"];
                case "buttonc":
                    return bv["C"];
                default:
                    break;
            }
            return null;
        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
            ProcessClick(sender);
        }
        private void ButtonB_Click(object sender, EventArgs e)
        {
            ProcessClick(sender);
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            ProcessClick(sender);
        }
      }
