            try
            {
                //get source item attachments from the folder
                SPFolder srcAttachmentsFolder =
                    srcItem.Web.Folders["Lists"].SubFolders[srcItem.ParentList.Title].SubFolders["Attachments"].SubFolders[srcItem.ID.ToString()];
                //Add items to the target item
                foreach (SPFile file in srcAttachmentsFolder.Files)
                {
                    byte[] binFile = file.OpenBinary();
                    tgtItem.Update();
                    tgtItem.Attachments.AddNow(file.Name, binFile);
                    tgtItem.Update();
                }
            }
            catch
            {
                //exception message goes here
            }
            finally
            {
                srcItem.Web.Dispose();
            }
        }
