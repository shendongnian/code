        public void readf()
        {
            int j;
            int i;
            var flag = 0;
            var str = "BCD";
            var c1 = str.ToCharArray();
            var str2 = "ABBCDEF";
            var fs = str2.ToCharArray();
            for (i = 0; i < fs.Length; i++) //loop for file
            {
                if (flag == c1.Length) // All characters in the search string where found.
                {
                    Console.WriteLine("found");
                    break; 
                }
                for (j = 0; j < c1.Length;) //loop for user string input
                {
                    if (c1[j] == fs[i + j]) // By evaluating i + j, you don't lose your place within the file. 
                    {
                        flag = flag + 1;
                        j++;
                        continue;
                    }
                    flag = 0;
                    break;
                }
            }  // End file loop
            Assert.AreEqual(flag, c1.Length);
        }
