            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    TESTEntities db = new TESTEntities();
                    List<MyTableBis2> myDataList = db.MyTableBis2.ToList();
                    string valuerFull = "";
                    foreach (MyTableBis2 data in myDataList)
                    {
                        valuerFull += data.CharCol + " ";
                    }
                    MessageBox.Show(valuerFull);
                    var newValueAdd = textBox1.Text.Trim();
                    
                    MessageBox.Show(newValueAdd);
    
                    var ch = myDataList.FirstOrDefault(x => x.CharCol.Equals(newValueAdd));
                    if (ch == null)
                    {
                        MyTableBis2 m = new MyTableBis2();
                        m.CharCol = textBox1.Text.Trim();
                        db.MyTableBis2.Add(m);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("This product exist");
                    }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Exception innerE = ex.InnerException;
                    while (innerE != null)
                    {
                        MessageBox.Show(innerE.Message);
                        innerE = innerE.InnerException;
                    }
                }
            }
