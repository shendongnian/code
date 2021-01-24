    public partial class Form1 : Form, IForms
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        public void InitializeParameters(params object[] args)
        {
            if (args.Length==2)
            {
                string param1 = args[0].ToString();
                int param2 = (int)args[1];
            }
            else
            {
                throw new Exception("The number of parameters is incorrect");
            }
    
        }       
    }
