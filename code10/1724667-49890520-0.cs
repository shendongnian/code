    protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ListSource"] = new List<string>
            {
                "a",
                "b",
                "c"
            };
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["ListSource"] = new List<string>
            {
                "d",
                "e"
            };
        }
