    int a, b, sum = 0;
                   
        Console.WriteLine("Enter the fist number ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second number ");
        b = Convert.ToInt32(Console.ReadLine());
      if (a<b){
        for (int x = a+1; x < b; x++)
        {
            sum += x * x;
        }
		 Console.WriteLine(sum);
	  }
		else{
			Console.WriteLine("Wrong input!");
		}
        Console.ReadLine();
	}
}
    
