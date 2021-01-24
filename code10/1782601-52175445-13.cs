    ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["shopmanagerConnectionString1"]
    string Query = "select * from shopmanager.quotes where idquotes = @search_quote_number;";
    using(MySqlConnection con = new MySqlConnection(conSettings.ToString()))
    {
      using(MySqlCommand cmdDataBase = new MySqlCommand(Query, con))
      {
        cmdDataBase.Parameters.AddWithValue("@search_quote_number", search_quote_number.Text.Trim());
        con.Open();
        var myReader = cmdDataBase.ExecuteReader();
        if(myReader.Read())
        {
          temp_client_id.client_id = myReader.GetString("client_info_client_number");
          quote_id.Text = myReader.GetInt16("idquotes").ToString();
          client_name.Text = myReader.GetString("client_name");
          predicted_start_date.Text = myReader.GetString("predicted_start_date");
          date_required.Text = sdate_required = myReader.GetString("requested_date");
          date_predicted.Tex = myReader.GetString("delivery_expected_date");
          date_received.Text = myReader.GetString("date_received");
          quote_amount.Text = myReader.GetString("quote_amount");
          project_number.Text = DBNull.Value.Equals(myReader.GetString("projects_project_number")) ? "" : myReader.GetString("projects_project_number");
     
          search_quote_number.Text = "";
        }
      }
    }
