    using (var conn = new OracleConnection("Password=xxxxx;Persist Security Info=True;User ID=xxxxxxx;Data Source=xxxxxx"))
    {
    string sql = "SELECT X, Y FROM Z WHERE ABC = 123";
    var orderDetail = conn.Query(sql).FirstOrDefault();
        foreach (var pair in orderDetail)
        {
            Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
        }
    }
    Output: 
    VALUE_A = 'Y'
    VALUE_B = 'Y'
