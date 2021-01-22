    private SPListItem CopyItem(SPListItem sourceItem, string destinationListName) {
            //Copy sourceItem to destinationList
            SPList destinationList = sourceItem.Web.Lists[destinationListName];
            SPListItem targetItem = destinationList.Items.Add();
            foreach (SPField f in sourceItem.Fields) {
                //Copy all except attachments.
                if (!f.ReadOnlyField && f.InternalName != "Attachments"
                    && null != sourceItem[f.InternalName])
                {
                    targetItem[f.InternalName] = sourceItem[f.InternalName];
                }
            }
            //Copy attachments
            foreach (string fileName in sourceItem.Attachments) {
                SPFile file = sourceItem.ParentList.ParentWeb.GetFile(sourceItem.Attachments.UrlPrefix + fileName);
                byte[] imageData = file.OpenBinary();
                targetItem.Attachments.Add(fileName, imageData);
            }
            return targetItem;
        }
