                var query = dc.GetTable<Media>().Where(s => s.MediaID == new Guid("A72AA79A-6C40-4D6B-A826-241553FECDFE"));
                var query1 = dc.GetTable<MediaVersion>().Where(s => s.MediaID == new Guid("A72AA79A-6C40-4D6B-A826-241553FECDFE"));
                var query2 = dc.GetTable<RootPath>().Where(s => s.RootPathID == new Guid("62145B2C-BA36-4313-8CA2-0F224F8FE7E8"));
                SqlCommand cmd = dc.GetCommand(query) as SqlCommand;
                //Load first
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds, "Media");
                //Load second
                cmd = dc.GetCommand(query1) as SqlCommand;
                ada.SelectCommand = cmd;
                ada.Fill(ds, "MediaVersion");
                ds.Relations.Add("Med_MedVer", ds.Tables["Media"].Columns["MediaID"],
                           ds.Tables["MediaVersion"].Columns["MediaID"]);
                //Load third independent table
                cmd = dc.GetCommand(query2) as SqlCommand;
                ada.SelectCommand = cmd;
                ada.Fill(ds, "RootPath");
