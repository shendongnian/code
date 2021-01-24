    using (var conn = new OracleConnection("Password=dev2g0;Persist Security Info=True;User ID=A$FastEq_Apu;Data Source=repltirt"))
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
