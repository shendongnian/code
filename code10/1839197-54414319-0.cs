    for (int x = 0; x < Appliances.Count; x++)
                {
                    appButtons[x] = new Button();
                    appButtons[x].Size = new System.Drawing.Size(75, 25);
                    appButtons[x].Text = Appliances[x].Name;
                    ButtonBoard.Controls.Add(appButtons[x]);
                }
