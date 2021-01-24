        private int Chk()
        {
            string link = linkLabelPartner.Text;
            var result = (dynamic)null;
            using (DbModel db = new DbModel ())
            {
                result = db.users.Where(x => x.lastname + " " + x.firstname == link ).Select(x => x.users).FirstOrDefault();
            }
            return result;
        }     
        private void btnTey_Click(object sender, EventArgs e)
        {
            int test = Chk();
            MessageBox.Show(test.ToString());
        }
