    XmlNodeList elemList = doc.GetElementsByTagName("book");
                        for (int j = 0; j < elemList.Count; j++)
                        {
                            if (elemList[j].Attributes["category"].Value == "COOKING")
                            {
                                XmlNodeList elemList1 = doc.GetElementsByTagName("author");
                                for (int i = 0; i < elemList1.Count; i++)
                                {
                                    string attrVal = elemList1[i].Attributes["lang"].Value;
                                    string attrVal1 = elemList1[i].Attributes["auth"].Value;
    
                                    ListViewItem lvi = new ListViewItem();
    
                                        lvi.SubItems.Add(attrVal1);
                                        lvi.SubItems.Add(attrVal1);
                                    }
                                    listView1.Items.Add(lvi);
                                }
                            }
                        }
