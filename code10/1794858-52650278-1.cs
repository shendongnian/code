    string date = DateTime.Now.ToString("MMMM-dd-yyyy");
    string shortdate = DateTime.Now.ToString("-MMddy-");
    private void Quantity_TextChanged(object sender, EventArgs e)
    {
        Code.Text = Supplier.Text.Substring(0, 3) + shortdate + Quantity.Text;
    }
            using (var con = SQLConnection.GetConnection())
            {
                using (var selects = new SqlCommand("Update Product_Details set quantity = quantity - @Quantity, CodeItem = @Code where ProductID= @ProductID", con))
                {
                    selects.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = _view.txt_productid.Text;
                    selects.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
                    selects.Parameters.Add("@Code", Code.Text);
                }
            }
