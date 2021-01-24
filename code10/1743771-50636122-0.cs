    int i=1;
    while(i==1)
    {
      try {
                Console.WriteLine("your question");
                int number= int.Parse(Console.ReadLine());
                i=0;
            }
            catch (Exception)
            {
              i=1;
                Console.WriteLine("Please Enter a Number");
            }
    }
    
