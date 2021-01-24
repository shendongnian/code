     public partial class GeneralForm : Form
    {
        public Client CurrClient;
        public GeneralForm(string ClientName)
        {
            string FormName = ClientName;
            CurrClient = new Client();
            InitializeComponent();
        }
}
