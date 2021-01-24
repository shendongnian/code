     foreach (TabPage tabControl in tabControl1.Controls)
                {
                    foreach (Control item in tabControl.Controls)
                    {
                        if (item is Label)
                           //your logic here
                            item.Text = "Hello";
                    }
                }
