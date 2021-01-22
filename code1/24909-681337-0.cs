        NewProduct newproduct;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(!isOpened())
            {
                newproduct = new NewProduct();
                newproduct.Show();
            }
            
        }
        private bool isOpened()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f == newproduct)
                {
                    return true;
                }
            }
            return false;
        }
