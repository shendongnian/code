            const int Maximum_Identical = 2; // Max number of identical characters in a row 
            const string lower_chars = "abcdefghijklmnopqrstuvwxyz"; // lower case chars
            const string capital_chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //capital chars
            const string numbers = "0123456789"; //numbers
            const string symbols = @"!#$%&*@\"; //symbols
            int lenght = 6; //
            bool lowercase = true, capital=true, num=true, sym=true;
            List<char[]> PasswordSet = new List<char[]>();
            List<char[]> charSet = new List<char[]>();
            List<int[]> countSet = new List<int[]>();
            if (lowercase) charSet.Add(lower_chars.ToArray());
            if (capital) charSet.Add(capital_chars.ToArray());
            if (num) charSet.Add(numbers.ToArray());
            if (sym) charSet.Add(symbols.ToArray());
            foreach(var c in charSet)
                countSet.Add(new int[c.Length]);
            Random rdm = new Random();
            //we create alist with each type with a length char (max repeat char included)
            for(int i = 0; i < charSet.Count;i++)
            {
                var lng = 1;
                var p0 = "";
                while (true)
                {
                    var ind = rdm.Next(0, charSet[i].Length);
                    if (countSet[i][ind] < Maximum_Identical )
                    {
                        countSet[i][ind] += 1;
                        lng++;
                        p0 += charSet[i][ind];
                    }
                    if (lng == lenght) break;
                }
                PasswordSet.Add(p0.ToArray());
            }
            //generate a password with the desired length with at less one char in desired type,
            //and we choose randomly in desired type to complete the length of password
            var password = "";
            for(int i = 0; i < lenght; i++)
            {
                char p;
                if (i < PasswordSet.Count)
                {                   
                    int id;
                    do
                    {
                        id = rdm.Next(0, PasswordSet[i].Length);
                        p = PasswordSet[i][id];
                    } while (p == '\0');
                    password += p;
                    PasswordSet[i][id] = '\0';
                }
                else
                {
                    int id0;
                    int id1;
                    do
                    {
                        id0 = rdm.Next(0, PasswordSet.Count);
                        id1 = rdm.Next(0, PasswordSet[id0].Length);
                        p = PasswordSet[id0][id1];
                    } while (p == '\0');
                    password += p;
                    PasswordSet[id0][id1] = '\0';
                }
            }
            //you could shuffle the final password
            password = Shuffle.StringMixer(password);
