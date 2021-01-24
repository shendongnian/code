     <input id="date" type="Date" min="1905-01-01" max="2019-01-01" value="2018-01-01" runat = "server"/>
.
   
     OleDbConnection connection = new OleDbConnection();
        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\WebSites\MyWebsite\DataBase.mdb;Persist Security Info=False;";
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        connection.Open();
        command.CommandText = "insert into users (FirstName, LastName, Place, Email, UserName, Birthday) values('" + firstname.Text + "','" + lastname.Text + "','" + PlaceList.Text + "','" + MyEmail.Text + "','" + AccountText.Text + "','" + date.Text + "')";
        command.ExecuteNonQuery();
