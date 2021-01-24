    protected void Page_Load(object sender, EventArgs e)
    {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.fixer.io/latest?base=JPY&symbols=SGD"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string json;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                json = reader.ReadToEnd();
            }
            var rates = JsonConvert.DeserializeObject<Item>(json);
            Item r = new Item();
            r = (Item)(rates);
            Rates rb = (Rates)r.rates;
            lblResult.Text = lblResult.Text + "" + rb.SGD;
        }
