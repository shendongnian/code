        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Second.aspx");
        }
    
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Third.aspx?Name=Pants");
        }
    
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Third.aspx?Name=Shoes");
        }
