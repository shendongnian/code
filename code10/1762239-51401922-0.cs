    public MainPage()
    {
        InitializeComponent();
        RefreshData();
    }
    public void RefreshButton_Click(object sender, EventArgs e) => RefreshData();
    private void RefreshData()
    {
        var cli = new WebClient();
        cli.Headers[HttpRequestHeader.ContentType] = "application/json";
        string response = cli.UploadString("Can't share company API and token sorry");
        var responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Ihap>(response);
        IthalatGunluk.Text = responseModel.Import.ToString();
        IthalatAylik.Text = responseModel.ImportMonthly.ToString();
        IthalatYillik.Text = responseModel.ImportMonthlyPrevious.ToString();
        IhracatGunluk.Text = responseModel.Export.ToString();
        IhracatAylik.Text = responseModel.ExportMonthly.ToString();
        IhracatYillik.Text = responseModel.ExportMonthlyPrevious.ToString();
        Dolar.Text = responseModel.Dolar.ToString();
        Euro.Text = responseModel.Euro.ToString();
    }
