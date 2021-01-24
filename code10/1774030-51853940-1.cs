     public partial class AddNewdbObjects : Form
            {
             //isSuccess is a flage that will be true if the new object is added to db or no
            public isSuccess = false;
            //After Constructor in your click event
            private void btnSave_Click(object sender, EventArgs e)
                    {
                        //Intialize data base source;
                        _db = new DBEntities();
                        dbObject obj = new dbObject();
                        obj.Name = txtName.Text;
                        try
                        {
                            _db.dbObject.Add(cust);
                            _db.SaveChanges();
                            isSuccess = true;
                            this.Close();
                        }
                        catch (Exception exc)
                        {
                            isSuccess = false;
                        }
            }
        }
