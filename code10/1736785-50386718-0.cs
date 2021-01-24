     try
                {
                    var doc = new XmlDocument();
                    doc.Load(AppDomain.CurrentDomain.BaseDirectory + "/test.xml");
    
                    var node = doc.SelectSingleNode("a");
                    if (node != null)
                    {
                        MessageBox.Show("a Exist");
                    }
                    else
                        MessageBox.Show("a Not Found");
                }
                catch (Exception) { }
