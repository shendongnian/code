     string message = "";
                foreach (ListItem item in ListBox1.Items)
                {
                    if (item.Selected == true)
                    {
                        message += item.Text + " " + item.Value + "\\n";
                    }
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
