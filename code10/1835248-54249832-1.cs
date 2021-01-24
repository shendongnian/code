    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["UpdateProdOrder"] = HiddenField1.Value;
        Label1.Text = string.Format("Session value is now '{0}'", Session["UpdateProdOrder"]);
    }
