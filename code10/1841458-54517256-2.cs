    static IEnumerable<int> ToRange(this int credit, int startNumber)
    {
         // example: Credit 40 is 40 times more chance than credit 1.
         // so range length is equal to credit
         return Enumerable.Range(startNumber, credit);
    }
    static IEnumerable<int> ToRange(this IEnumerable<Ad> adds)
    {
        int startNumber = 0;
        foreach (Ad add in adds)
        {
            // only use ads that are not displayed yet to select a new Ad.
            if (!ad.IsDisplayed)
            {
                 var range = add.Credit.ToRange();
                 foreach (var value in range) yield return value;
            }
        }
    }
    
