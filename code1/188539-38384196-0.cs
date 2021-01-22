    class Program
    {
        static void Main(string[] args)
        {
            var sDireccion = @"http://localhost:5984/base_principal/_all_docs";
            var client = new WebClient { Credentials = new NetworkCredential("zzz", "zzz + zzz"), Encoding = Encoding.UTF8 };
            var sRespuesta = client.DownloadString(sDireccion);
            cClaseBase cBase = new cClaseBase();
            cBase = JsonConvert.DeserializeObject<cClaseBase>(sRespuesta);
            foreach (Row str in cBase.rows)
            {
                sDireccion = @"http://localhost:5984/base_principal/"+str.id;
                sRespuesta = client.DownloadString(sDireccion);
                cClaseDetalle cd = new cClaseDetalle();
                cd = JsonConvert.DeserializeObject<cClaseDetalle>(sRespuesta);
            }
        }
