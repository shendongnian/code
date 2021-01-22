            string s;
            int input;
            string[] placement = { "thousand", "hundred", "ten", "" };
            string[] numbersToLetters = { "", "one", "two", "tre", "four", "five", "six", "seven", "eight", "nine" };
            for (int i = 0; i < s.Length; i++)
            {
                int digits = 3 - i; //placement[3] is the maximum value in the array. Since you can't have an input with the value NULL.
                //-i negates the loop value i. E.g this will produce an output of nothing.
                if (s[i] - 48 != 0){ //Make sure input is not zero. There is no such thing as zeroten.
                    digits = 4 - s.Length; 
                }
                int result = int.Parse(s[i].ToString()); //Convert char unicode to regular in
                
                Console.Write(numbersToLetters[result + placering[i + digits]);
            }
