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
            // Intended output Xest, Actual output: Xest
            Console.WriteLine(internedString2);
            // Intended output test, Actual output: Xest
            Console.WriteLine(nonInternedString);
            // Intended output Xest bla, Actual output: Xest bla
            Console.WriteLine(nonInternedString2);
            // Intended output test bla, Actual output: test bla
