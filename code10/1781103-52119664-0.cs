            for (i = 0; i < fs.Length; i++)
            {
                if (c1[0] == fs[i])
                {
                    for (var j = 1; j < c1.Length;) //loop for user string input
                    {
                        if (c1[j] != fs[i = j])
                        {
                            break;
                        }
                    }
                    Console.WriteLine("found");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("not found");
            Console.ReadLine();
