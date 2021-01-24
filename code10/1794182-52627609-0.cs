    //your class
    public class TestConnection {
    //the method name explains its function.
    //the query is stored within the function
    //therefore the functionality is encapsulated
    public string CheckLogin(int id)
    {
        //note: tricky: almost SQL injection here: that must be fixed.
        //I just left it here so you can see the basic idea
        var request = "SELECT Name FROM Names WHERE ID ="  + id.ToString();
        //another note: response doesn't have to be passed as parameter.
        var response = string.Empty;
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = "Server=SQLOLEDB.1;User ID=" +
                Constants.DATABASE_USERNAME + ";Password=" +
                Constants.DATABASE_PASSWORD + ";Initial Catalog=" +
                Constants.DATABASE_CATALOG + ";Data Source=" +
                Constants.SERVER_ADRESS;
            SqlCommand command = new SqlCommand(request, conn);
            {
                conn.Open();
                response = Convert.ToString (command.ExecuteScalar());
                conn.Close();
                return response; 
            }
        }
