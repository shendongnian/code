    public class Data
    {
        [JsonProperty(PropertyName = "krs_podmioty.data_sprawdzenia")]
        public DateTime data_sprawdzenia { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.regon")]
        public string regon { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.adres_lokal")]
        public string adres_lokal { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.adres_miejscowosc")]
        public string adres_miejscowosc { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.liczba_czlonkow_komitetu_zal")]
        public int liczba_czlonkow_komitetu_zal { get; set; }
    }
     var json = "{ \"data\": { \"krs_podmioty.data_sprawdzenia\": \"2016 -12-22T05:36:21\", \"krs_podmioty.regon\": \"0\", \"krs_podmioty.adres_lokal\": \"\", \"krs_podmioty.adres_miejscowosc\": \"Warszawa\", \"krs_podmioty.liczba_czlonkow_komitetu_zal\": 0,} }";
    
     var t = JsonConvert.DeserializeObject<Data>(json);
