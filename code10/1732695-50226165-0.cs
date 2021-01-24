    //At what location is the image being stored to
                MessageBox.Show($"Adding row {totalRows.ToString()}");
                //inserting the image into the row 
            MySqlCommand insertCommand = new MySqlCommand("insert into testimages.image_information(FaceID, FaceNo, Name, Image) 
				values(@faceid, @faceno, @name, @img)", connection);
                MySqlParameter imageParam;
                insertCommand.Parameters.Add("@faceid", MySqlDbType.Int16,25);
               insertCommand.Parameters.Add("@faceno", MySqlDbType.Int16, 25);
              insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 25);
                insertCommand.Parameters.Add("@img", MySqlDbType.Binary);
            insertCommand.Parameters["@faceid"].Value = totalRows.ToString();
            insertCommand.Parameters["@faceno"].Value = totalRows.ToString();
                insertCommand.Parameters["@name"].Value = tbSetFaceLabel.Text;
                insertCommand.Parameters["@img"].Value = facesToByte;
                int rowAffected = insertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Stored Successfully in " 
				+ rowAffected.ToString() + " Rows");
