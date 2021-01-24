    protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButton rbLogoSeleccionado = (RadioButton)e.Item.FindControl("rb1");
                string script = "SetUniqueRadioButton('repeater1.*nameGroup',this)";
                rbLogoSeleccionado.Attributes.Add("onclick", script);
            }
        }
        catch (Exception ex)
        {
            PIPEvo.Log.Log.RegistrarError(ex);
            throw;
        }
    }
