    string foo = "banana";
                List<string> chars = new List<string>();
                Random rnd = new Random();
                string newPassword = "";
                for (int i = 0; i < foo.Length; i++)
                {
                    chars.Add(foo[i].ToString());
                }
                foreach (var boo in chars)
                {
                    var randomNum = rnd.Next(0, 2);
                    Debug.WriteLine(randomNum);
                    if (randomNum == 0)
                    {
                        newPassword = newPassword + boo.ToUpper();
                    }
                    else
                    {
                        newPassword = newPassword + boo.ToLower();
                    }
                }
                Debug.WriteLine(newPassword);
