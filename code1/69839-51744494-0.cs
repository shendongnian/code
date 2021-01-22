    unsafe
    {
         string a = "Test";
         string b = a;
         fixed (char* p = a)
         {
              p[0] = 'B';
         }
         Console.WriteLine(a); // output: "Best"
         Console.WriteLine(b); // output: "Best"
    }
