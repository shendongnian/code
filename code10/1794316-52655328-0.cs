    //input html to be field 
                NameValueCollection Data = new NameValueCollection();
                Data.Add("bResultat", "true");
                Data.Add("ModeAffichage", "COMPLET");
                Data.Add("bImpression", "");
                Data.Add("AERO_Date_DATE", "2018/10/04");
                Data.Add("AERO_Date_HEURE", "21:50");
                Data.Add("AERO_Langue", "FR");
                Data.Add("AERO_Duree", "12");
                Data.Add("AERO_CM_REGLE", "1");
                Data.Add("AERO_CM_GPS", "2");
                Data.Add("AERO_CM_INFO_COMP", "1");
                Data.Add("AERO_Tab_Aero[0]", "EDDM");
                Data.Add("AERO_Tab_Aero[1]", "EDDF");
                Data.Add("AERO_Tab_Aero[2]", "EDDL");
                Data.Add("AERO_Tab_Aero[3]", "EDDV");
                Data.Add("AERO_Tab_Aero[4]", "EDDN");
                //Create the data in good format
                var parameters = new StringBuilder();
                foreach (string key in Data.Keys)
                {                    
                   parameters.AppendFormat("{0}={1}&",
                   System.Web.HttpUtility.UrlEncode(key),
                   System.Web.HttpUtility.UrlEncode(Data[key]));
                }
                parameters.Length -= 1;               
                byte[] bytedata = Encoding.UTF8.GetBytes(parameters.ToString());
                //request to server
                HttpWebRequest req =(HttpWebRequest)WebRequest.Create("http://notamweb.aviation-civile.gouv.fr/Script/IHM/Bul_Aerodrome.php");
                
                req.Method = WebRequestMethods.Http.Post;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bytedata.Length;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bytedata, 0, bytedata.Length);
                reqStream.Close();
                MessageBox.Show(bytedata.Length.ToString() + " - " + parameters);
                WebResponse response = req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
