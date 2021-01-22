    if(rdr["quantity"] != null) {
        int? number = null;
        if(int.TryParse(rdr["quantity"].ToString(), out number)) {
            Console.WriteLine("Hurray, I have an int. Up vote Coov!");
        }
    }
