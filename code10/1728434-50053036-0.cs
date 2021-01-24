    public partial class ProxyScraperForm : Form
    {
    
        private BindingList<IProxyScraperSite> sites = new BindingList<IProxyScraperSite>();
        private ConcurrentDictionary<string, FirefoxDriver> activeDrivers = new ConcurrentDictionary<string, FirefoxDriver>();
        private object lockObj = new object();
    
        public BindingList<IProxyScraperSite> Sites { get { return this.sites; } }
    
        public ProxyScraperForm()
        {
            InitializeComponent();
    
            sites.Add(new ProxyScraperSiteUsProxyOrg());
            sites.Add(new ProxyScraperSiteFreeProxyListNet());
            sites.Add(new ProxyScraperSiteFreeProxyListsNet());
            sites.Add(new ProxyScraperSiteHideMyName());
            sites.Add(new ProxyScraperSiteHidester());
            scraperDataGridView.DataSource = sites;
        }
    
        private void scrapeButton_Click(object sender, EventArgs e)
        {
            foreach (var site in sites)
            {
                Task.Run(async () =>
                {
                    var driver = SeleniumUtility.CreateDefaultFirefoxDriver();
                    activeDrivers.TryAdd(site.SiteName, driver);
                    await site.ScrapeAsync(driver);
                    lock (lockObj)
                    {
                        driver.Quit();
                    }
                    activeDrivers.TryRemove(site.SiteName, out driver);
                });
            }
        }
    
        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (var driver in activeDrivers)
            {
                lock (lockObj)
                {
                    driver.Value.Quit();
                }
            }
    
            activeDrivers.Clear();
    
            foreach (var site in sites)
            {
                site.Status = "Idle";
            }
        }
    
        private void proxyScraperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopButton.PerformClick();
            this.DialogResult = DialogResult.Cancel;
        }
    }
