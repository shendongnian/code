     for (int i = 0; i < lstEquipmentItem.Items.Count; i++)
                    {
                        if ((bool)ds.Tables[0].Rows[i]["Valid_Equipment"] == false)
                        {
                            lblTKMWarning.Text = "Invalid Equipment & Serial Numbers are highlited.";
                            lblTKMWarning.ForeColor = System.Drawing.Color.Red;
                            lstEquipmentItem.Items[i].Attributes.Add("style", "background-color:Yellow");
                            Count++;
                        }
    
                    }
