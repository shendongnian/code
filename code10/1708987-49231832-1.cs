    try
    {
        String myConnection = "datasource=localhost; port=3306; username=root;password=admin; database=dbstudents;";
        //Images Conversion : Datatype in my database is LONGBLOB
        Byte[] img = File.ReadAllbytes(imgLoc);
        // this is a sample query for update statement and update 
        String Query = "UPDATE tblstudent RIGHT JOIN tbltransact  ON tblstudent.StudentID = tbltransact.EnrolleeID SET FirstName=@firstName , LastName=@lastName , MiddleName=@middleName ,ContactNo=@contactNo ,Address=@address ,Age=@age ,Guardian=@guardian,studentPic=@studentPic,PendingBalance=@pendingBalance, WHERE StudentID=@studentID";
        MySqlCommand cin = new MySqlCommand(Query, myConn);
        using (MySqlConnection myConn = new MySqlConnection(myConnection))
        {
            myConn.Open();
            cin.Parameters.AddWithValue("@studentID", Int32.Parse(search.Text));
            cin.Parameters.AddWithValue("@firstName", firstname.Text);
            cin.Parameters.AddWithValue("@lastName", lastname.Text);
            cin.Parameters.AddWithValue("@middleName", middlename.Text);
            cin.Parameters.AddWithValue("@contactNo", ContactNum.Text);
            cin.Parameters.AddWithValue("@address", address.Text);
            cin.Parameters.AddWithValue("@age", Int32.Parse(age.Text));
            cin.Parameters.AddWithValue("@guardian", guardian.Text);
            cin.Parameters.AddWithValue("@studentPic", img );
            cin.Parameters.AddWithValue("@pendingBalance", Int32.Parse(Balance.Text));
            if (cin.ExecuteNonQuery() == 0)
            {
                // Handle query failure here
                MessageBox.Show(String.Format("No patient found to update for ID {0}", search.Text));
            }
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
