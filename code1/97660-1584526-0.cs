    public static void GetDetails()
    {
        int ctr = 0;
        char[] sym = new char[] { '+', '-', '/', '*' };
        string num = "5";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        ctr++;
                        string str = num + sym[i] + num + sym[j] + num + sym[k] + num;
                        Console.WriteLine("res = " + str + "; ");
                        Console.WriteLine("if(res>=1 && res<=10)");
                        Console.WriteLine("Console.WriteLine(\"" + str + "\");");
                    }
                }
            }
        }
        //Console.WriteLine("Total:" + ctr.ToString());
    }
