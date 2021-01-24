       public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                if (Device.OS == TargetPlatform.iOS)
                    Padding = new Thickness(10, 50, 0, 0);
                else if (Device.OS == TargetPlatform.Android)
                    Padding = new Thickness(10, 20, 0, 0);
                else if (Device.OS == TargetPlatform.WinPhone)
                    Padding = new Thickness(30, 20, 0, 0);
            }
            Image UpArrowImage
            {
                get { return "Upimage path"; }
            }
            Image DownArrowImage
            {
                get { return "Downimage path"; }
            }
            private void Button_Clicked(object sender, EventArgs e)
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                XmlElement root = doc1.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Currency");
                foreach (XmlNode node in nodes)
                {
                    var attributeKod = node.Attributes["Kod"].Value;
                    if (attributeKod.Equals("USD"))
                    {
                        var getBanknoteSellingUSD = node.SelectNodes("BanknoteSelling")[0].InnerText;
                        var getBanknoteBuyingUSD = node.SelectNodes("BanknoteBuying")[0].InnerText;
                        var banknoteSellingUSD = float.Parse(getBanknoteSellingUSD);
                        var banknoteBuyingUSD = float.Parse(getBanknoteBuyingUSD);
                        var sell = banknoteSellingUSD.ToString("0.00");
                        var buy= banknoteBuyingUSD.ToString("0.00");
                        labelUsdSELLING.Text = sell;
                        labelUsdBUYING.Text = buy;
                     
                        this.pictureBox1.Image = (float.Parse(buy) >float.Parse( sell))?UpArrowImage:DownArrowImage;
                        }
                       
                    }
                    var attributeKod1 = node.Attributes["Kod"].Value;
                    if (attributeKod1.Equals("EUR"))
                    {
                        var getBanknoteSellingEU = node.SelectNodes("BanknoteSelling")[0].InnerText;
                        var getBanknotesBuyingEU = node.SelectNodes("BanknoteBuying")[0].InnerText;
                        var banknoteSellingEU = float.Parse(getBanknoteSellingEU);
                        var banknoteBuyingEU = float.Parse(getBanknotesBuyingEU);
                        labelEuSELLING.Text = banknoteSellingEU.ToString("0.00");
                        labelEuBUYING.Text = banknoteBuyingEU.ToString("0.00");
                    }
                }
            }
