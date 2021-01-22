            try
            {
                ModalPopupExtender1.Show();
                if (ViewState["Colors"] != null)
                {
                    FillColors(ViewState["Colors"].ToString());
                }
                DropDownList dropDownListColor = (DropDownList)sender;
                DataListItem dataListItem = (DataListItem)dropDownListColor.Parent;
                Image image = (Image)dataListItem.FindControl("mdlImage");
                Label ProductCode = (Label)dataListItem.FindControl("lblprdCode");
                Label ProductName = (Label)dataListItem.FindControl("lblProdName");
                DropDownList ddlQuantity = (DropDownList)dataListItem.FindControl("ddlQuantity");
                Label ProductPrice = (Label)dataListItem.FindControl("lblProdPrice");
                Label TotalPrice = (Label)dataListItem.FindControl("lblTotPrice");
                //Label ProductPrice = (Label)dataListItem.FindControl("lblProdPrice");
                 
            }
            catch (Exception ex)
            {
            }
        }
