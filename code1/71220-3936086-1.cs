    private static Random random = new Random();
            
    private static string CreateTempPass(int size)
            {
                var pass = new StringBuilder();
                for (var i=0; i < size; i++)
                {
                    var binary = random.Next(0,2);
                    switch (binary)
                    {
                        case 0:
                        var ch = (Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65))));
                            pass.Append(ch);
                            break;
                        case 1:
                            var num = random.Next(1, 10);
                            pass.Append(num);
                            break;
                    }
                }
                return pass.ToString();
            }
