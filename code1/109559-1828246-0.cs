            private void CopyItem(SPListItem sourceItem, string destinationListName)
            {
                SPList destinationList = sourceItem.Web.Lists[destinationListName];
                SPListItem targetItem = destinationList.Items.Add();
                foreach (SPField field in sourceItem.Fields)
                {
                    if (!field.ReadOnlyField && field.InternalName != "Attachments")
                    {
                        targetItem[field.Title] = sourceItem[field.Title];
                    }
                }
                foreach (string fileName in sourceItem.Attachments)
                {
                    SPFile file = sourceItem.ParentList.ParentWeb.GetFile(
                        sourceItem.Attachments.UrlPrefix + fileName);
                    byte[] imageData = file.OpenBinary();
                    targetItem.Attachments.Add(fileName, imageData);
                }
                targetItem.Update();
            }
