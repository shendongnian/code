    using (SqlCommand comm = new SqlCommand("PP_CreateNumber", connection))
    {
          comm.CommandType = CommandType.StoredProcedure;
          // This never changes inside the loop so keep it outside
          comm.Parameters.Add("@loadSheetNum", SqlDbType.NVarChar).Value = lblSheet.Text);
          // This changes inside the loop so set the value inside the loop
          comm.Parameters.Add("@Number", SqlDbType.NVarChar)
          for (int i = 0; i < ContentPlaceHolder1.Controls.Count; i++)
          {
                Control ctrl = ContentPlaceHolder1.Controls[i];
                if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    value = txt.Text;
                    int parsedValue;
                    if (!int.TryParse(value, out parsedValue))
                    {
                        lblError.Text = "Please enter only numeric values for number";
                        return;
                    }
                    else
                    {
                         comm.Parameters["@Number"] = value;
                         comm.ExecuteNonQuery();
                    }
               }
          }
    }
     
