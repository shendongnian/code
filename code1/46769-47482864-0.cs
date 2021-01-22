    //This method is recursive. It simply returns all the possible arrangements by going down
    //and building all possible combinations of parenthesis arrangements by starting from "()"
    //Using only "()" for n == 1, it puts one "()" before, one "()" after and one "()" around
    //each paren string returned from the call stack below. Since, we are adding to a set, the
    //set ensure that any combination is not repeated.
    private HashSet<string> GetParens(int num)
    {
        //If num < 1, return null.
        if (num < 1) return null;
        //If num == 1, there is only valid combination. Return that.
        if (num == 1) return new HashSet<string> {"()"};
        //Calling myself, by subtracting 1 from the input to get valid combinations for 1 less
        //pair.
        var parensNumMinusOne = GetParens(num - 1);
        //Initializing a set which will hold all the valid paren combinations.
        var returnSet = new HashSet<string>();
        //Now generating combinations by using all n - 1 valid paren combinations one by one.
        foreach (var paren in parensNumMinusOne)
        {
            //Putting "()" before the valid paren string...
            returnSet.Add("()" + paren);
    
            //Putting "()" after the valid paren string...
            returnSet.Add(paren + "()");
    
            //Putting paren pair around the valid paren string...
            returnSet.Add("(" + paren + ")");
        }
        return returnSet;
    }
