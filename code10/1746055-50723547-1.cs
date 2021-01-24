    using System.Linq;
    var isAMatch = _context.HoldingBucket.Any(x => x.AccountName.ToLower() == Request.Account_Name.ToLower());
    // _context is what you provided me in the comments as your connection string variable
    // isAMatch will either be true or false
    if(isAMatch) // if there is a match
        doSomething();
    else // if there is no match
        doSomethingElse();
