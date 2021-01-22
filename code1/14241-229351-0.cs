            string internedString = "test";
            string internedString2 = "test";
            string nonInternedString = "";
            string nonInternedString2 = "";
            nonInternedString += internedString + " bla";
            nonInternedString2 += internedString + " bla";
            unsafe 
            {
                fixed (char* str = internedString)
                {
                    *str = 'X';
                }
                fixed (char* str = nonInternedString)
                {
                    *str = 'X';
                }
            }
            Console.WriteLine(internedString);
            Console.WriteLine(internedString2);
            Console.WriteLine(nonInternedString);
            Console.WriteLine(nonInternedString2);
