    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace PronouncablePasswords
    {
        class PasswordGenerator
        {
            //string vowels = "aeiou";
            //string consonants = "bcdfghjklmnprstvwxyz";
    
            /*
               The reason for the duplicate letters is to add "weighting" to certain letters to allow them more chance
               of being randomly selected.  This is due to the fact that certain letters in the English language are more
               frequently used than others.
            
               The breakdown of usage is as follows (from most frequent to least frequent):
                1. 	E                   (7)
                2. 	T                   (6)
                3. 	A, O, N, R, I, S    (5)
                4.	H                   (4)
                5. 	D, L, F, C, M, U    (3)
                6. 	G, Y, P, W, B       (2)
                7. 	V, K, X, J, Q, Z    (1)
            */
    
            string vowels = "aaaaaeeeeeeeiiiiiooooouuu";
            string consonants = "bbcccdddfffgghhhhjklllmmmnnnnnpprrrrrsssssttttttvwwxyyz";
    
            string[] vowelafter = {"th", "ch", "sh", "qu"};
            string[] consonantafter = { "oo", "ee" };
            Random rnd = new Random();
    
            public string GeneratePassword(int length)
            {
                string pass = "";
                bool isvowel = false;
    
                for (int i = 0; i < length; i++)
                {
                    if (isvowel)
                    {
                        if (rnd.Next(0, 5) == 0 && i<(length-1))
                        {
                            pass += consonantafter[rnd.Next(0, consonantafter.Length)];
                        }
                        else
                        {
                            pass += vowels.Substring(rnd.Next(0, vowels.Length), 1);
                        }
                    }
                    else
                    {
                        if (rnd.Next(0, 5) == 0 && i<(length-1))
                        {
                            pass += vowelafter[rnd.Next(0, vowelafter.Length)];
                        }
                        else
                        {
                            pass += consonants.Substring(rnd.Next(0, consonants.Length), 1);
                        }
                    }
                    isvowel = !isvowel;
                }
                return pass;
            }
        }
    }
