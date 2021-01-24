     query = new SqlCommand ("Select UserType from singleTable where UserName = @userName", conn);
        query.Parameters.AddWithValue("@userName", userName.Text);                    
        dr = query.ExecuteReader ();
        if (dr.Read ())
          {
              MessageBox.Show ("Login is successful. Welcome '"+ userName.Text +"'");
              if(Convert.ToInt32(dr["UserType"]) == 1) {
                adminPanel form = new adminPanel ();
               }
              else if (Convert.ToInt32(dr["UserType"]) == 2) {
                teacherPanel form = new teacherPanel ();
               }
        
               else if (Convert.ToInt32(dr["UserType"])== 3) {
            studentPanel form = new studentPanel ();
             }
        
           }
