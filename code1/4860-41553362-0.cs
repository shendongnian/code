     foreach (string value in Enum.GetNames(typeof(Response)))
                        ddlResponse.Items.Add(new ListItem()
                        {
                            Text = value,
                            Value = ((int)Enum.Parse(typeof(Response), value)).ToString()
                        });
