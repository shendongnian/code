                for (int i=0; i<customerInTheTank.Count;i++)
                {
                        if (DropDownListRegion.SelectedValue == "Funen" && customerInTheTank[i].Region == "Funen")
                        {
                            ListBoxFunen.Items.Add(customerInTheTank[i].Name);
                        }
                }
