        public void InsertCostumer(string name, int age, string address)
        {
            List<object> myList = new List<object>();
            myList.Add(name);
            myList.Add(age);
            myList.Add(address);
            StringBuilder queryInsert = new StringBuilder();
            queryInsert.Append("insert into Customers(name, age, address) values (");
            int i = 0;
            foreach (var param in myList.ToArray())
            {
                if (param == null)
                {
                    queryInsert.Append("null, ");
                    myList.RemoveAt(i);
                }
                else
                {
                    queryInsert.Append("{" + i + "}, ");
                    i++;
                }
            }
    
            queryInsert.Remove(queryInsert.Length - 2, 2);
            queryInsert.Append(")");
    
            this.myDataContext.ExecuteCommand(queryInsert.ToString(), myList.ToArray());
        }
