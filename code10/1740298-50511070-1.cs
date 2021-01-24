    tableA.Columns.Add("Issued"); 
    
    // the join assumes your ID field is of type int. Change type/names as appropriate
    var query = from rowA in tableA.AsEnumerable()
    			join rowB in tableB.AsEnumerable() 
    			on rowA.Field<int>("ID") equals rowB.Field<int>("ID") into grp 
    			from B in grp.DefaultIfEmpty()
    			select new { A = rowA, B }; 
    			
    foreach (var pair in query)
    {
    	if (pair.B != null)
    		pair.A["Issued"] = "Yes"; 
    	else
    		pair.A["Issued"] = "No";
    }
