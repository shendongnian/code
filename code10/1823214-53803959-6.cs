    var properties =  typeof(Employee).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(IncludeinReport))).Select(v=>v);
    var intermediate = list.OrderBy(c => c.Region).ThenBy(x=>x.BusinessUnit).SelectMany((x,index)=> properties.Select(v=> new {GroupId = index, Dict = new KeyValuePair<string,object>(v.Name, v.GetValue(x))})) ;
    var resultList = new List<ExpandoObject>();
    
     foreach(var item in intermediate.GroupBy(x=>x.GroupId))
     {
    	resultList.Add(CreateObject(item.ToList().Select(x=>x.Dict)));
     }
