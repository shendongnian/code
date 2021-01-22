        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnShow.Click += new EventHandler(btnShow_Click);
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            modal.Show();
        }
 
