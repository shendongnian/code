                            // To access checkbox list item's value //
                        string total = "";
                        foreach (ListItem listItem in listbox_software.Items)
                        {
                            if (listItem.Selected)
                            {
                                total =  total + "[" + listItem.Value + "][ " + " ";
                            }
                        }
                        string str = total.ToString();
