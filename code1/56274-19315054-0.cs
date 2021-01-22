        XmlNodeList xnodeContact = xmldocContact.GetElementsByTagName("contact");
            
  
              foreach (ListViewItem item in listViewContacts.Items)
                {
                    if (item.Checked)
                    {
                        if (item.Index >= 0)
                            xnodeContact[0].ParentNode.RemoveChild(xnodeContact[0]);
                            listViewContacts.Items.Remove(item);
                              
                            
                        }
                    }
                }
                xmldocContact.Save(appdataPath + "\\WhatAppcontactList.xml");
                Invalidate();
