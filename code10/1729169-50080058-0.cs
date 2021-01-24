    public class OgrenciModel
    {
        public int OgrenciID { get; set; }
        public string KurumKod { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string AdSoyad { get; set; }
        public string Sinif { get; set; }
        public string EtutSinif { get; set; }
        public string KayitNo { get; set; }
        public string Yon { get; set; }
        public string VeliAdi { get; set; }
        public string VeliSoyadi { get; set; }
        public string VeliAdSoyad { get; set; }
        public string VeliYakinlik { get; set; }
        public string OgrenciFoto { get; set; }
        public string VeliFoto { get; set; }
        public List<OgrenciModel> GetOgrenciModels()
        {
            string Kurumkod = Settings.SettingsKurumKodu.ToString();
            string[] Sinif = Settings.SettingsSinifAdi.Split(',');
            if (Kurumkod != null && Sinif[0] != "Seçilmedi!")
            {
                string Tarih = DateTime.Now.ToString("yyyy-MM-dd");
                string Saat = DateTime.Now.AddSeconds(-3).ToString("HH:mm:ss"); // güncel zamanın 3 saniye gerisine gider.
                string sorgu = "SELECT ...............;
                string AnonsSorgusu = Provider.ServiceManager.SorguGonder(sorgu);
                string[] Anonslistesi = AnonsSorgusu.Split(Environment.NewLine.ToCharArray());
                List<OgrenciModel> ogrenciModels = new List<OgrenciModel>();
                foreach (string item in Anonslistesi)
                {
                    string[] AnonsBilgisiParcala = item.ToString().Split('|');
                    ogrenciModels.Add(new OgrenciModel()
                    {
                        AdSoyad = AnonsBilgisiParcala[17].ToString(),
                       VeliAdSoyad = AnonsBilgisiParcala[18].ToString(),
                        OgrenciFoto = "http://........jpg"
                    }
                    );
                }
                return ogrenciModels;
            }
            return null;
        }
    }
