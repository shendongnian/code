    // Only use the values of dictionary 2:
    IEnumerable<List<List<string>>> dict2Values = dictionary2.Values
    // then for easy comparison extract the first list
    var separatedFirstList = dict2Values.Select(listOfLists=> new
    {
         FirstList = listOfLists.FirstOrDefault(), // this is a List<string> or null
         AllLists = listOfLists,    // original List<List<string>> where FirstList is the first
    })
    // keep only the elements that have a first list:
    .Where(stringListWithFirstElement => stringListWithFirstElement.FirstList != null);
