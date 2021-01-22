    public static void LimpiarArchivosViejos()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            int hora = DateTime.Now.Hour;
            if(today == DayOfWeek.Monday || today == DayOfWeek.Tuesday && hora < 12 && hora > 8)
            {
                CleanPdfOlds();
                CleanExcelsOlds();
            }
            
        }
        private static void CleanPdfOlds(){
            string[] files = Directory.GetFiles("../../Users/Maxi/Source/Repos/13-12-2017_config_pdfListados/ApplicaAccWeb/Uploads/Reports");
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTime < DateTime.Now.AddDays(-7))
                    fi.Delete();
            }
        }
        private static void CleanExcelsOlds()
        {
            string[] files2 = Directory.GetFiles("../../Users/Maxi/Source/Repos/13-12-2017_config_pdfListados/ApplicaAccWeb/Uploads/Excels");
            foreach (string file in files2)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTime < DateTime.Now.AddDays(-7))
                    fi.Delete();
            }
        }
