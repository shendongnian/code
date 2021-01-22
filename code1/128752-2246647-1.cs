    protected void btnPutToCache_Click(object sender, EventArgs e) {
            Cache["data"] = txtData.Text;
        }
        protected void btnGetFromCache_Click(object sender, EventArgs e) {
            lblGetFromCache.Text = Cache["data"].ToString();
        }
