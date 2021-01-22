    protected void cmdSave_OnClick(object sender, EventArgs e)
    {
        ArrayList itemsOrdered = new ArrayList();
        foreach (GridViewRow gvr in gvMainOrderForm.Rows)
        {
            Label lblItemId = (Label)(gvr.FindControl("lblItemId"));
            string itemId = lblItemId.Text;
            foreach (string availableOption in availableOptions)
            {
                TextBox tb = (TextBox)(gvr.FindControl("tb" + availableOption));
                if (tb.Text != "")
                {
                    ArrayList itemOrdered = new ArrayList();
                    itemOrdered.Add(itemId);
                    itemOrdered.Add(availableOption);
                    itemOrdered.Add(tb.Text);
                    itemsOrdered.Add(itemOrdered);
                }
            }
        }
    }
