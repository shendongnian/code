    protected void dlPartnerCat_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var _partCatlbl = e.Item.FindControl("lblPartCat") as Label
        if (_partCatlbl != null)
        {
            switch (_partCatlbl.Text)
            {
                case "Customer":
                    _partCatlbl.CssClass = ApplicationCssHelper.CustomerClass;
                    break;
                case "Customer - Supplier":
                    _partCatlbl.CssClass = ApplicationCssHelper.Customer_SupplierClass;
                    break;
                case "Supplier":
                    _partCatlbl.CssClass = ApplicationCssHelper.SupplierClass;
                    break;
                case "Agent":
                    _partCatlbl.CssClass = ApplicationCssHelper.AgentClass;
                    break;
                default:
                    _partCatlbl.CssClass = ApplicationCssHelper.WarningClass;
                    break;
            }
        }
    }
