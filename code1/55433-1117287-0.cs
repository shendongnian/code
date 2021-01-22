    public void InsertCostumer(string? name, int? age, string? address)
    {
        List<object> myList = new List<object>();
        myList.Add(name.GetValueOrDefault());
        myList.Add(age.GetValueOrDefault());
        myList.Add(address.GetValueOrDefault());
        StringBuilder queryInsert = new StringBuilder();
        queryInsert.Append("insert into Customers(name, address) values ({0}, {1}, {2})");
        this.myDataContext.ExecuteCommand(queryInsert.ToString(), myList.ToArray());
    }
