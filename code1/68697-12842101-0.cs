    public static SPListItem CopyItem(SPListItem sourceItem, SPList destinationList)
                {
                    SPListItem targetItem = destinationList.AddItem();
        
                    //loop over the soureitem, restore it
                    for (int i = sourceItem.Versions.Count - 1; i >= 0; i--)
                    {
                        //set the values into the archive 
                        foreach (SPField sourceField in sourceItem.Fields)
                        {
                            SPListItemVersion version = sourceItem.Versions[i];
        
                            if ((!sourceField.ReadOnlyField) && (sourceField.InternalName != "Attachments"))
                            {
                                SetFields(targetItem, sourceField, version);
                            }
                        }
        
                        //update the archive item and 
                        //loop over the the next version
                        targetItem.Update();
                    }
        
                    foreach (string fileName in sourceItem.Attachments)
                    {
                        SPFile file = sourceItem.ParentList.ParentWeb.GetFile(sourceItem.Attachments.UrlPrefix + fileName);
                        targetItem.Attachments.Add(fileName, file.OpenBinary());
                    }
        
                    targetItem.SystemUpdate();
                    return targetItem;
                }
        
                private static bool SetFields(SPListItem targetItem, SPField sourceField, SPListItemVersion version)
                {
                    try
                    {
                        targetItem[sourceField.InternalName] = version.ListItem[sourceField.InternalName];
                        return true;
                    }
                    catch (System.ArgumentException)//field not filled
                    {
                        return false;
                    }
                    catch (SPException)//field not filled
                    {
                        return false;
                    }
                }
