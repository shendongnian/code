            static string ToBinary2(int input)
            {
                List<string> results = new List<string>(); ;
                while (input > 1)
                {
                    results.Insert(0,(input % 2) == 0 ? "0" : "1");
                    input /= 2;
                }
                return string.Join("", results) ;
     
            }
