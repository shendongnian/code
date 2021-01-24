    bool greater = false;
    while (greater == false)
    {
       Console.WriteLine("Enter your name: ");
       string userName3 = Console.ReadLine();
       if (userName3.Length >= 5)
       {
          greater = true;
       }
       else
       {
          Console.WriteLine("The name must be 5 characters or more");
       }
    }
    string[] userNameArr = userName3.Split();
    Console.WriteLine(userNameArr[0] + " " + userNameArr[2] + " " + userNameArr[4]);
