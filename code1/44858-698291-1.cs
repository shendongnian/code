    public void imgBtnClick(Object sender, System.EventArgs e)
    {
        String url = "http://www.erate.co.za/CompanyProfile.aspx?ID=" + reader.Item("Desc_Work").ToString;
        Response.Redirect(url, false);
    }
