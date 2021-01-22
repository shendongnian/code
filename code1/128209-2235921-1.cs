        if (Application["menu"] != null)
        {
            litMenu.Text = Application["menu"].ToString();
        }
        else
        {
            try
            {
                System.Net.WebRequest wrq = System.Net.WebRequest.Create(ConfigurationManager.AppSettings["MenuPath"]);
                System.Net.WebResponse wrp = wrq.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(wrp.GetResponseStream());
                litMenu.Text = sr.ReadToEnd();
                Application["menu"] = litMenu.Text;
            }
            catch
            {
                Application["menu"] = litMenu.Text;
            }
        }
