    public Dictionary<string,List<string>> getAllComboboxBindingLists(string listTypes)
    {
       var resultList = new  Dictionary<string,List<string>>>();
       resultList.Add('carTypes',new List<string>{"sgh","shd","dfh"});
       resultList.Add('studentTypes',new List<string>{"dfg","fgh","dhh"});
       if(listTypes != null)//here listtypes will be a semicolon spllitted string like 'type1;type2'
       {
        var splittedList=listTypes.split(';');
         resultList=resultList.where(r=> splittedList.Contains(r.key))
       }
       return resultList;
    }
