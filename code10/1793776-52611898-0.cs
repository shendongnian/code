               while (myReader1.Read())
                {
                    oldStartDate = myReader1.GetDateTime("predicted_start_date");
                    oldFinishDate = myReader1.GetDateTime("predicted_delivery");
                    newStartDate = oldStartDate.AddDays(delay);
                    newFinishDate = oldFinishDate.AddDays(delay);
                    UpdateNewStartDate(partId, newStartDate, newFinishDate);
                }
                cmd1.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con1.Close();
           
