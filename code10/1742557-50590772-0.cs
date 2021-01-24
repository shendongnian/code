    var SelectedUser = (from Client in ClientsContext.Clients
                                               where Client.ID == id
                                               select Client).FirstOrDefault();
    if(SelectedUser!=null){
                        SelectedUser.Password = txtPassword.Text.Trim();
                        SelectedUser.UID = txtUID.Text.Trim();
                        SelectedUser.Name = txtName.Text.Trim();
                        SelectedUser.IsActive = chkUserActiveSatus.Checked;
                        SelectedUser.ItemListAccess = chkItemListAccess.Checked;
                        SelectedUser.MaterialSumAccess = chkMaterialSummeryAccess.Checked;
                        SelectedUser.PartListAccess = chkPartListAccess.Checked;
                        SelectedUser.PriceListAccess = chkPriceListAcess.Checked;
                        ClientsContext.SubmitChanges();
    }
    else{
    //write your logic
    }*
