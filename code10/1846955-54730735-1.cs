    var sqlConnection = new SqlConnection("Data Source=<<dbserver>>; Initial Catalog=<<dbname>>;uid=<<uid>>;password=<<password>>");
    var adapter = new SqlDataAdapter();
    var str = "'" + string.Join("','", ss) + "'";
    // Instead of looping thru all the items of ss to query the database again and again
    // I am using IN query to query the database in one opration.
    string sqlstmt = "SELECT * FROM myTable where c1 IN (" + str + ") or c2 IN (" + str +")";
    DataSet dataSet = new DataSet();
    sqlConnection.Open();
    adapter = new SqlDataAdapter(sqlstmt, sqlConnection);
    adapter.Fill(dataSet);
    sqlConnection.Close();
    dataGridView1.DataSource = dataSet.Tables[0];
    //With above code GridView1 displayed data a following.
       c1   |     c2    | c3   
    ----------------------------
     hello	|  friends  | 250
     hi	    |  guys	    | 15
     good	|  day	    | 15684
     old	|  days	    | 156153
     bye	|  bye	    | 6143
    // With following line of code I am trying to remove duplicate query parameters.
    // I am doing this because Same SELECT statement is being used 
    // to query the data for both GridView1 and GridView2.
    // Only the parameter value changes.
    myNEWFORDGV1 = myNEWFORDGV1.Except(ss).ToArray();
    str = "'" + string.Join("','", myNEWFORDGV1) + "'";
    string query = "SELECT * FROM myTable where c1 IN (" + str + ") or c2 IN (" + str + ")";
    dataSet = new DataSet();
    adapter = new SqlDataAdapter(query, sqlConnection);
    adapter.Fill(dataSet);
    sqlConnection.Close();
    dataGridView2.DataSource = dataSet.Tables[0];
   
    GridView2 will display following data now.
       c1   |     c2    | c3   
    ----------------------------
     new	|  coders	| 88
     january|  february	| 31
     such	|  good	    | 1684
     play	|  music	| 1553
