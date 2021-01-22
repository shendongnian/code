    public void Run()
    {
        string filename = "MikeD.txt";
        using (var tr = new StreamReader(filename))
        {
            string line = null;
            while ((line= tr.ReadLine()) != null)
            {
                System.Console.WriteLine("#orig: {0}",line);
                var tokens = line.Split('|');
                if (tokens.Length == 4)
                {
                    // find first numeric digit in tokens[0]
                    int n=0;
                    while(tokens[0][n]<'0' || tokens[0][n]>'9') n++;
                    // get the base for the first output argument
                    int b1 = Int32.Parse(tokens[0].Substring(n));
                    // get the prefix for the first output arg
                    string prefix = tokens[0].Substring(0,n);
                    // find the beginning index in tokens[2]
                    var p1 = tokens[2].Substring(1).Split('-');
                    int b2 = Int32.Parse(p1[0]);
                    // find the extension in tokens[2]
                    var p2 = tokens[2].Split('.');
                    string ext = p2[1];
                    // determine how many lines to output
                    int x = Int32.Parse(tokens[3]);
                    // output the lines
                    for (int i=0; i < x; i++)
                    {
                        System.Console.WriteLine("{0}{1}|{2}|{3}.{4}",
                                                 prefix,
                                                 b1+i,
                                                 tokens[1],
                                                 b2+i,
                                                 ext
                                                 );
                    }
                }
                else
                {
                    System.Console.WriteLine("-bad input-");
                }
            }
        }
    }
