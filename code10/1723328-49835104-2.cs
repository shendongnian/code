    // needs:  using System.Linq;
    private static void Encrypt(int shift, string input, string alphabet)
    {
        var message = new StringBuilder();
	    // create a string that is shifted by shift characters	
		// skip: skips n characters, take: takes n characters
		// string.Join reassables the string from the enumerable of chars
		var moved = string.Join("",alphabet.Skip(shift))+string.Join("",alphabet.Take(shift));
		
        // the select iterates through your alphabet, c is the character you currently handle,
        // i is the index it is at inside of alphabet
        // the rest is a fancy way of creating a dictionary for 
        // a->d
        // b->e
        // etc   using alphabet and the shifted lookup-string we created above.
		var lookup = alphabet
            .Select( (c,i)=> new {Orig=c,Chiff=moved[i]})
            .ToDictionary(k => k.Orig, v => v.Chiff);
		
			
        foreach (char letter in input)
        {
            // if the letter is not inside your alphabet, you might want to add
            // it "as-is" in a else-branch. (Numbers or dates or .-,?! f.e.)
			if (lookup.ContainsKey(letter)) 
			{
				message.Append(lookup[letter]);
			}
		}
        Console.WriteLine("\n" + message);
    }
