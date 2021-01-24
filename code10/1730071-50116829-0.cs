    	List<int> ls = new List<int>();
		ls.Add(5);
		ls.Add(7);
		ls.Add(9);
		ls.Add(11);
		string sql = string.Format( "select Id1 from T where Id2 in ({0})", string.Join(",",ls.Select(n=> "@prm"+n).ToArray()));
		SqlCommand cmd = new SqlCommand(sql);
		foreach(int n in ls){
			cmd.Parameters.AddWithValue("@prm"+n, n);
		}
