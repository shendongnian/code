            CultureInfo english = new CultureInfo("en-US", false);
            CultureInfo turkish = new CultureInfo("tr-TR", false);
            foreach (String i in new String[] { "a", "e", "i", "o", "u" })
            {
                String iEng = i.ToUpper(english);
                String iTur = i.ToUpper(turkish);
                Console.Write(i); 
                Console.WriteLine(iEng == iTur ? " Equal" : " Not equal");
            }
            Console.ReadLine();
