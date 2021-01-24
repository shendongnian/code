    // Here I'm just converting a string to an IEnumerable<int>, a collection of integers basically
    IEnumerable<int> ints1 = Console.ReadLine()
                                    .ToCharArray()
                                    .Select(i => Convert.ToInt32(i.ToString()));
    IEnumerable<int> ints2 = Console.ReadLine()
                                    .ToCharArray()
                                    .Select(i => Convert.ToInt32(i.ToString()));
        
    // Zip brings together two arrays and iterates through both at the same time.
    // I used an anonymous object to store the original values as well as the calculated ones
    var zippedArrays = ints1.Zip(ints2, (i, j) => new
                                        {
                                            First = i,    // original value from ints1
                                            Second = j,   // original values from ints2
                                            Total = i + j // calculated value ints1[x] + ints2[x]
                                        });
                                        
    
                                      
    // if the totals are [4,4,4], the method below will get rid of the duplicates.
    // if the totals are [4,3,5], every element in that array would be returned
    // if the totals are [4,4,5], only [4,5] would be returned.
    var distinctByTotal = zippedArrays.GroupBy(x => x.Total);
    
    // So what does this tell us? if the returned collection has a total count of 1 item,
    // it means that every item in the collection must have had the same total sum
    // So we can say that every element is equal if the response of our method == 1.
    
    bool isEqual = distinctByTotal.Count() == 1;
