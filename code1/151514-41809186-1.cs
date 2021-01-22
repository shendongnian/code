    ...
    ...
    // calling code.
    var userDetails = await GetUserDetails(userId);
    Console.WriteLine("Username : {0}", userDetails.Item1);
    Console.WriteLine("User Region Id : {0}", userDetails.Item2);
    ...
    ...
    
    private async Tuple<string,int> GetUserDetails(int userId)
    {
        return new Tuple<string,int>("Amogh",105);
        // Note that I can also use the existing helper method (Tuple.Create).
    }
