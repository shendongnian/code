    string test = @"<START>
                       <A>message<B><BEOF>UnknownLengthOfText<AEOF>
                       <A>message<B><BEOF>UnknownLengthOfText<AEOF>
                    <END>";
    
    //for this test this will give u an array containing 3 items...
    string[] tmp1 = test.Split("<AEOF>");
    
    //here u will store your results in
    List<string> results = new List<string>();
    
    //for every single one of those 3 items:
    foreach(string item in tmp1)
    {
         //this will only be true for the first and second item
         if(item.Contains("<A>"))
         {
               string[] tmp2 = item.Split("<A>");
               //As the string you are looking for is always BEHIND the <A> you 
               //store the item[1], (the item[0] would be in front)
               results.Add(tmp2[1]);
         }
    }
