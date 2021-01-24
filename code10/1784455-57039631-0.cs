     string sentence=Console.ReadLine();
    		
                if (String.IsNullOrEmpty(sentence))
                {
    
                    Console.WriteLine("Please, do not leave the sentence field empty!");
                    Console.WriteLine("Enter your desired sentence again: ");
                    sentence = Console.ReadLine();
                }
                else if(sentence.Length!=6)
                {
                    Console.WriteLine("\r\nThe sentece entered isn't valid. Must have a least six words!");
                    Console.WriteLine("Enter a sentence with a least 6 words: ");
                    sentence =  Console.ReadLine();
                }
    			else
    			{
    			Console.WriteLine("Your entered string length is'{0}' and word is{1}", sentence.Length,sentence);
    			}
