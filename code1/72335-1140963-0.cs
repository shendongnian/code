    object recs;
    
    ADODB.Connection conn = new ADODB.Connection();
    ADODB.Recordset rs = new ADODB.Recordset();
    // You may need to provide user id and password instead of empty strings		
    conn.Open("Provider=ADsDSOObject", "", "", 0);
    
    // replace <> elements with your server name and OU/DC tree org
    string server = "<enter your server name here>";
    string start = "OU=<blah>,DC=<blah>,DC=<blah>,DC=<blah>";
    string where = "objectClass = '*'";
    string qry = string.Format("SELECT cn FROM 'LDAP://{0}/{1}' WHERE {2}", server, start, where);
    
    rs = conn.Execute(qry, out recs, 0);
    
    for (; !rs.EOF; rs.MoveNext())
    {
    	Console.WriteLine(rs.Fields["cn"].Value.ToString());
    }
