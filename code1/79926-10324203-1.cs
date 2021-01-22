    protected void btnQuteSearch_Click(object sender, EventArgs e)
    {
        pPopupQuoteSearch.Style.Remove("display");
        pPopupQuoteSearch.Style.Add("display", "inline");
        dQuoteContainer.InnerHtml = "some HTML code";
        ModalPopupExtender1.Show();
    }
