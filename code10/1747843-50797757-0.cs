     public void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
     {
            Dictionary<string, string> dicOperationTypes = new Dictionary<string, string>();
            dicOperationTypes.Add("Select", "0");
            switch (dllSyncType.SelectedValue)
            {
                case "1":
                    dicOperationTypes.Add("Check", "1");
                    dicOperationTypes.Add("Open", "2");
                    dicOperationTypes.Add("Close", "3");
                    break;
                case "2":
                    dicOperationTypes.Add("Activate", "4");
                    dicOperationTypes.Add("Deactivate", "5");
                    break;
                case "3":
                    dicOperationTypes.Add("Update", "6");
                    dicOperationTypes.Add("Activate", "4");
                    dicOperationTypes.Add("Deactivate", "5");
                    break;
                case "4":
                    // related Operation Types with Product
                    break;
                case "5":
                    // related Operation Types with Open/Close Property
                    break;
                case "6":
                    // related Operation Types with Sync All
                    break;
                default:
                    break;
            }
            ddlOperationType.DataSource = dicOperationTypes;
            ddlOperationType.DataValueField = "Value";
            ddlOperationType.DataTextField = "Key";
            ddlOperationType.DataBind();
     }
