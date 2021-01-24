    //Your result class should actually look like this to match JSON:
    class DropDownListDto
    {
        public string Description {get;set;}
        //here you need an IEnumerable to store the list of Ids and values associated
        //with this drop-down.  you could create a class and declare a LIST<> of that
        //but I'll just use a dictionary instead.
        public Dictionary<int, string> DropDownValues{get;set;}
    }
    //Get source data
    var source = await GetDropDownValues(<insert [] here>);
    //transform list into IEnumerable<DropDownListDto>
    var result = source
        //if we GROUP BY the Dropdown property then we'll get a distinct list of
        //of drop-downs.
        .GroupBy(x=>x.DropDown)
        //can then get the list of values and Ids from the resulting groups
        .Select(g=>new DropDownListDto
             {
                  //key is the grouped by thing - drop down name..
                  Description = g.Key,
                  //doing a .select from the group result gives the elements
                  //in that group only.  Get an anonymous type and cast that
                  //to our required dictionary type
                  DropDownValues = g
                    .Select(x=>new{ key=x.Id, value = x.Value})
                    .ToDictionary(k=>k.key, v=>v.value)
             });
