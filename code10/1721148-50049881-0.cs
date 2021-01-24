    var input = Enumerable.Range(0, 101);
    var topTwo = input.Aggregate((Biggest: Int32.MinValue, SecondBiggest: Int32.MinValue),
                                 (acc, next) =>
                                 {
                                     if (next > acc.Biggest)
                                     {
                                         acc.SecondBiggest = acc.Biggest;
                                         acc.Biggest = next;
                                     }
                                     if (next > acc.SecondBiggest && next < acc.Biggest)
                                         acc.SecondBiggest = next;
                                     return acc;
                                 });
                                     
    WriteLine(topTwo.SecondBiggest);  // 99
