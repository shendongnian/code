        protected void Page_Load(object sender, EventArgs e)
        {
            string val = ClientScript.GetPostBackEventReference(this,"");
         }
          protected void Date_ValueChanged(object sender, EventArgs e)
        {
            string value = HiddenField1.Value;
            //do your db stuffs
        }
