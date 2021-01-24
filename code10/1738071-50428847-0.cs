    class m2m_cin {
        public string con { get; set; }
    }
    var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, m2m_cin>>(responseString);
    string con_raw = resp["m2m:cin"].con;
