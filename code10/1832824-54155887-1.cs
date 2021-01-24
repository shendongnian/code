    Console.WriteLine("Entrez une phrase SVP!!");
    string phrase = Console.ReadLine();
    string newPhrase = ""; 
    // loop through each character in phrase		
    for (int i = 0; i < phrase.Length; i++) {
       // We check if the character of phrease is within our newPhrase, if it isn't we add it, otherwise do nothing
       if (newPhrase.IndexOf(phrase[i]) == -1) 
    		newPhrase += phrase[i]; // here we add it to newPhrase
    }
    
    Console.WriteLine(newPhrase);
