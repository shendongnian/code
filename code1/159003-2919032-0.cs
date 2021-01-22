    using System;
    namespace CommandLine{
	class Test{
		
		[STAThread]
		static void Main(string[] Args)
        {
            Console.WriteLine("Enter the word: ");
            string regWord = Console.ReadLine();
            string vowWord = VowelWord(regWord);
            Console.WriteLine("Regural word {0} is now become {1}", regWord, vowWord);
            Console.ReadKey();
        }
        static string VowelWord(string word)
        {
            string VowelWord = string.Empty;
            char replChar;
            foreach (char c in word.ToCharArray())
            {
                switch(c)
                {
                        //'e' would be 'i', 'i' would be 'o', 'o' would be 'u', and finally 'u' would be 'a'.
                    case 'a' : replChar = 'e' ;
                        break;
                    case 'e': replChar = 'i';
                        break;
                    case 'i': replChar = 'o';
                        break;
                    case 'o' : replChar = 'u';
                        break;
                    case 'u' : replChar = 'a';
                        break;
                    default: replChar = c;
                        break;
                }
                VowelWord += replChar;
            }
            return VowelWord;
        }
		}
	}
