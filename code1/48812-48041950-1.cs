        //Generic C# Method
                private static List<T[]> GetPerms<T>(T[] input, int startIndex = 0)
                {
                    var perms = new List<T[]>();
                    var l = input.Length - 1;
                    if (l == startIndex)
                        perms.Add(input);
                    else
                    {
                        for (int i = startIndex; i <= l; i++)
                        {
                            var copy = input.ToArray(); //make copy
                            var temp = copy[startIndex];
                            copy[startIndex] = copy[i];
                            copy[i] = temp;
                            perms.AddRange(GetPerms(copy, startIndex + 1));
                        }
                    }
                    return perms;
                }
                //usages
                char[] charArray = new char[] { 'A', 'B', 'C' };
                var charPerms = GetPerms(charArray);
                string[] stringArray = new string[] { "Orange", "Mango", "Apple" };
                var stringPerms = GetPerms(stringArray);
                int[] intArray = new int[] { 1, 2, 3 };
                var intPerms = GetPerms(intArray);
