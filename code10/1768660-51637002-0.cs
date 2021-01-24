    namespace SimpleTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scrape_work(sender, e);
            statistics(sender, e);
        }
        protected void scrape_work(object sender, EventArgs e)
        {
            //Scraping work (works fine)
        }
        protected void statistics(object sender, EventArgs e)
        {
            int count = 666;
            scrapeNumLbl.Text = count.ToString();
        }
    }
