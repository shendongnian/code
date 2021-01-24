    var list = new List<string>();
    list.Add("Employee1");
    list.Add("Account");
    list.Add("100.5600,A+   ,John");
    list.Add("1.00000,A+     ,John");
    list.Add("USA");
    
    //prepare the list, I decided to make a tuple with the original string in the list and the splitted array
    var preparedItems = list.Select(x => (x, x.Split(',')));
    //group the prepared list to get matching items for the 2nd and 3rd part of the split, I therefor used .Skip(1) on the previously prepared array
    var groupedItems = preparedItems.GroupBy(x => string.Join(",", x.Item2.Skip(1).Select(y => y.Trim())));
    //"evaluate" the group by saying if the items in the group is > 1 only use the first part of the prepared array and if it doesnt have more than one entry use the orignal string 
    var evaluatedItems = groupedItems.SelectMany(x => x.Count() > 1 ? x.Select(y => y.Item2[0]) : x.Select(y => y.Item1));
    //replace the orignal list with the new result
    list = evaluatedItems.ToList();
