                for (int i=0; i<customerInTheTank.Count;i++)
                {
                        if (DropDownListRegion.SelectedValue == "Funen" && customerInTheTank[i].region == "Funen")
                        {
                            ListBoxFunen.Items.Add(customerInTheTank[i].Name);
                        }
                }
