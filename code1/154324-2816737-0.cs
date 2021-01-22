    void Page_Load()
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                BulletedList1.Items.Add("Deleting " + cookie);
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
