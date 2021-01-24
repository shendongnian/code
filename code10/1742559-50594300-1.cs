    private void UpdateClient()
            {
                if (ClientFormValidation())
                {
                        User.Password = txtPassword.Text.Trim();
                        User.UID = txtUID.Text.Trim();
                        User.Name = txtName.Text.Trim();
                        User.IsActive = chkUserActiveSatus.Checked;
                        User.ItemListAccess = chkItemListAccess.Checked;
                        User.MaterialSumAccess = chkMaterialSummeryAccess.Checked;
                        User.PartListAccess = chkPartListAccess.Checked;
                        User.PriceListAccess = chkPriceListAcess.Checked;
                        ClientsContext.SubmitChanges();
                }
            }
