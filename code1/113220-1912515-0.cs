    // Add the aggregators
    IFuture<int> total = voters.Count();
    IFuture<int> adults = voters.Count(voter => voter.Age >= 18);
    IFuture<int> children = voters.Where(voter => voter.Age < 18).Count();
    IFuture<int> youngest = voters.Min(voter => voter.Age);
    IFuture<int> oldest = voters.Select(voter => voter.Age).Max();
    
    // Push all the data through
    voters.ProduceAndEnd(Voter.AllVoters());
    
    // Write out the results
    Console.WriteLine("Total voters: {0}", total.Value);
    Console.WriteLine("Adult voters: {0}", adults.Value);
    Console.WriteLine("Child voters: {0}", children.Value);
    Console.WriteLine("Youngest vote age: {0}", youngest.Value);
    Console.WriteLine("Oldest voter age: {0}", oldest.Value);
