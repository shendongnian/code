        public List<Reporter> GetInquiries(string subject)
        {
            using (MyDataContextDataContext dc = conn.GetContext())
            {
                return (from spName in dc.spReporter()
                        select new Reporter(spName.Id, spName.InqDate, spName.Subject
                        where spName.Subject == subject)).ToList()
            }  
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {    
           GridView1.DataSource = GetInquiries(txtSubject.Text);
           GridView1.DataBind();
        }
