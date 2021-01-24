    if ((Convert.ToInt32(newDt.Rows[i]["qty"])) > (Convert.ToInt32(newDt1.Rows[i]["qty"])))
                {
                    k_batch = Convert.ToInt32(newDt.Rows[i]["batch_num"]);
                    label20.Content = k_batch.ToString();
                    var dqty = (from row in Addition_result.AsEnumerable()      //retriving value from DataTable
                                where row.Field<int>("batch_num") == k_batch
                                select row.Field<int>("qty")).FirstOrDefault();
                    dqty_y = Convert.ToInt32(dqty);
                    label16.Content = dqty_y.ToString();
                    try
                    {
                        //con.Open();
                        SqlCommand cmd1 = new SqlCommand("SELECT quantity,sold_qty,left_qty FROM batch WHERE id='" + k_batch + "'", con);
                        SqlDataReader batch_qty_details = null;
                        batch_qty_details = cmd1.ExecuteReader();
                        
                        while (batch_qty_details.Read())
                        {
                            label16.Content = dqty_y.ToString();
                            batch_qty = Convert.ToInt32(batch_qty_details["quantity"]);
                            batch_left = Convert.ToInt32(batch_qty_details["left_qty"]);
                            batch_sold = Convert.ToInt32(batch_qty_details["sold_qty"]);
                        }
                        con.Close();
                    }
                    catch(Exception EX)
                    {
                        MessageBox.Show(EX.ToString());
                        
                    }
                    label18.Content = batch_left.ToString();
                    label19.Content = batch_sold.ToString();
                    label21.Content = dqty_y.ToString();
                    label22.Content = batch_qty.ToString();
                    label16.Content = batch_sold + dqty_y;
                    label17.Content = batch_left - dqty_y;
                    if (((batch_sold + dqty_y) <= batch_qty) && ((batch_left - dqty_y) >= 0))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("update batch set sold_qty=sold_qty+@soldqty2, left_qty=left_qty-@soldqty2 where id=@id2", con);
                        command.Parameters.AddWithValue("@soldqty2", Convert.ToInt32(dqty_y));
                        command.Parameters.AddWithValue("@id2", Convert.ToInt32(k_batch));
                        rexe = command.ExecuteNonQuery();
                    }
                    else
                    {
                        check_qty = -1;
                        
                        
                    }
                   
                    
                }
