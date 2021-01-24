    namespace ScoreDuizenden
    {
        public partial class AantalSpelers : Form
        {
            public AantalSpelers()
            {
                InitializeComponent();
            }
    
            public string si;
            public void AantalSpelers_Load(object sender, EventArgs e)
            {
                NaamSpelers ns = new NaamSpelers();
                cbAantalSpelers.Items.Add("2");
                cbAantalSpelers.Items.Add("3");
                cbAantalSpelers.Items.Add("4");
    
            }
            public void btnDoorgaan_Click(object sender, EventArgs e)
            {
                si = cbAantalSpelers.Text;
                NaamSpelers ns = new NaamSpelers(si); // passing value to form through constructor
                ns.Show();
                this.Hide();
            }
        }
    }
