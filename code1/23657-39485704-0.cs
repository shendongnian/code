                        temp = Convert.ToDateTime(date);
                        date = temp.ToString("yyyy/MM/dd");
                    }
                    catch 
                    {
                        
                         MessageBox.Show("Sorry The date not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1,MessageBoxOptions .RightAlign);
                        date = null;
                    }
