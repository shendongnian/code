    var words = new List<object>()
                        {
                          5,
                          DateTime.Now,
                          "something else"
                        };
    
    var concatenatedResult = String.Join(" and ", words.Select(i => i.ToString()).ToArray());
    //should output "5 and [system time] and something else"
    Console.WriteLine(concatenatedResult);
    Console.ReadLine();
