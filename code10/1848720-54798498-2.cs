    public static Dictionary<String, int> processData(IEnumerable<string> lines)
    {
            Dictionary<String, int> retVal = new Dictionary<String, int>();
			var list = new List<Employee>();
			foreach(var user in lines)
			{
				var userDetails = user.Split(new []{','},StringSplitOptions.RemoveEmptyEntries);
				list.Add(new Employee
				{
				Id=int.Parse(userDetails[0]), 	
				UserName = userDetails[1],
				Department = userDetails[2],
				Salary = int.Parse(userDetails[3])
				});
	  	   }
			
			retVal = list.GroupBy(x=>x.Department).Select(x=>x.ToList()
                         .OrderByDescending(c=>c.Salary).First())
                         .ToDictionary(x=> x.Department, y=> y.Id);
            return retVal;
     }
