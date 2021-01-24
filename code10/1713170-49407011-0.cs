    public class Rootobject
    {
        public Data data { get; set; }
    }
    public class Data
    {
        [JsonProperty(PropertyName = "krs_podmioty.data_sprawdzenia")]
        public DateTime krs_podmiotydata_sprawdzenia { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.regon")]
        public string krs_podmiotyregon { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.adres_lokal")]
        public string krs_podmiotyadres_lokal { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.adres_miejscowosc")]
        public string krs_podmiotyadres_miejscowosc { get; set; }
        [JsonProperty(PropertyName = "krs_podmioty.liczba_czlonkow_komitetu_zal")]
        public int krs_podmiotyliczba_czlonkow_komitetu_zal { get; set; }
    }
