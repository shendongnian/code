    //In my knowledge i did this in simple way thanks for watch my code 
    static void Main(string[] args)
    {
        string a, b;
        int f1, f2, x, y;
        Console.WriteLine("Enter two inputs");
        a = Convert.ToString(Console.ReadLine());
        b = Console.ReadLine();
        f1 = find(a);   
        f2 = find(b);   
        if (f1 == 0 && f2 == 0)
        {
            x = Convert.ToInt32(a);
            y = Convert.ToInt32(b);
            Console.WriteLine("Two inputs r number \n so tha additon of these text box is= " + (x + y).ToString());
        }
        else
            Console.WriteLine("One or tho inputs r string \n so tha concadination of these text box is = " + (a + b));
        Console.ReadKey();
    }
        static int find(string s)
        {
        string s1 = "";
        int f;
         for (int i = 0; i < s.Length; i++)
            for (int j = 0; j <= 9; j++)
            {
                string c = j.ToString();
                if (c[0] == s[i])
                {
                    s1 += c[0];
                }
            }
        if (s==s1)
            f= 0;
        else
            f= 1;
        return f;
    }
