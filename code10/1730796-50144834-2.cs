    private void btnGetProduct_Click(object sender, EventArgs e)
    {
        if (Validator.IsPresent(txtCode))
        {
            Product product = this.GetProduct(txtCode.Text);
            if (product == null)
            {
                MessageBox.Show("No product found with this code. Please try again.", 
                    "Product Not Found");
                this.ClearControls();
            }
            else
            {
                this.DisplayProduct(product);
            }
        }
    }
