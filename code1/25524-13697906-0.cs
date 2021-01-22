            // Convert the string into a byte[].
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            for (int i = 0; i < value.Length; i++)
            
              
                {
                    Console.WriteLine(value.Substring(i, 1) + " as ASCII value of: " + asciiBytes[i]);
                }
