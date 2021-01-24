    protected void btn_Click(object sender, EventArgs e)
                {
                    List<string> items = new List<string>();
                    for(int i=0; i < chk1.Items.Count; i++)
                    {
                        if (chk1.Items[i].Selected == true)
                        {
                            //can do anything here
                            items[i] = chk1.Items[i].Text;
                        }
                    }
                }
