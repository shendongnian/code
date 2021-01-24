`
// lets group all of our id's and I'm not going to use groupby because I'm not a fan.
var itemsById = new Dictionary<string, List<MyDto>>();
foreach(var item in q)
{
   if(itemsById.ContainsKey(item.SomeId))
   {
       itemsById[item.SomeId].Add(item);
   }
   else 
   {
      itemsById.Add(item.SomeId, new List<MyDto>());
      itemsById[item.SomeId].Add(item);
   } 
}
so now we have dictionary of all of items by their ID.
var finalizedDtos = new List<MyDto>();
foreach(var entry in items)
{
   var finalizedDto = new MyDto{ someId = entry.Key };
   foreach(var innerDictionary in entry.value.JsonDictionary)
   {
                    var finalizedDto = new MyDto {SomeId = entry.Key};
                    var allKeyValuePairs = entry.Value.SelectMany(c => c.JsonDictionary);
                    finalizedDto.JsonDictionary = allKeyValuePairs.ToDictionary(key => key.Key, value => value.Value);
                    finalizedDtos.Add(finalizedDto);
   }
}
`
Not a whole lot of linq, but really for the nested structure I couldn't come up with a better plan
