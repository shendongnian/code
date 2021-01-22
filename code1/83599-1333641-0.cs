                using (SPSite oSite=new SPSite("http://mysharepoint"))
            {
                using (SPWeb oWeb=oSite.RootWeb)
                {
                    SPList oList = oWeb.Lists["Test"];
                    SPListItem oSPListItem = oList.Items.Add();
                    oSPListItem["Title"] = "Hello SharePoint";
                    oSPListItem.Update();
                }
                
            }
