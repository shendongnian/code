                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(250);
                    i++;
                    if (i > 3)
                        throw new Exception("Timedout waiting for input.");
                }
                input = Console.ReadLine();
