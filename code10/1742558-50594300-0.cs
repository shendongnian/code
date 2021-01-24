    public frmClientDefinition(Client thisClient=null)
            {
                
                InitializeComponent();
                if (thisClient!=null)
                {
                    User = thisClient;
                    id = thisClient.ID;
                    ISnewUser = false;
                    txtName.Text = thisClient.Name;
                    txtUsername.Text = thisClient.Username;
                    txtPassword.Text = thisClient.Password;
                    txtDate.Text = thisClient.Date.ToString();
                    txtUID.Text = thisClient.UID;
                    chkUserActiveSatus.Checked = thisClient.IsActive;
                    chkItemListAccess.Checked = thisClient.ItemListAccess;
                    chkPartListAccess.Checked = thisClient.PartListAccess;
                    chkMaterialSummeryAccess.Checked = thisClient.MaterialSumAccess;
                    chkPriceListAcess.Checked = thisClient.PriceListAccess;
                    chkFullPriceListAccess.Checked = false;
                    chkOfficialRecieptAccess.Checked = false;
                    chkNonOfficialRecieptAccess.Checked = false;
                    chkAdvancedPriceControlsAccess.Checked = false;
                    chkFullPriceListSaveAccess.Checked = false;
                    chkOfficialRecieptSaveAccess.Checked = false;
                    chkNonOfficialRecieptSaveAccess.Checked = false;
                    txtUsername.ReadOnly = true;
                }
                txtDate.Text = DateTime.Now.ToString();
            }
