    var code = String.Format("STA-100418-{0}", userinput);
            using (var con = SQLConnection.GetConnection())
            {
                using (var selects = new SqlCommand("Update Product_Details set quantity = quantity - @Quantity, CodeItem = @Code where ProductID= @ProductID", con))
                {
                    selects.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = _view.txt_productid.Text;
                    selects.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
                    selects.Parameters.Add("@Code", code);
                }
            }
