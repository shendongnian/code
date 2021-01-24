     foreach (TabPage tabControl in SubMenuTabControl.Controls)
                {
                    foreach (Control item in tabControl.Controls)
                    {
                        if (item is Label)
                           //your logic here
                            item.Text = "Hello";
                    }
                }
