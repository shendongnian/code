    Console.WriteLine("Enter two Numbers to start the Equation (X=Number , N=Power)" + "");
    int X = int.Parse(Console.ReadLine());
    int N = int.Parse(Console.ReadLine());
    double sum = 0;
    double up = 1;
    int down = 1;
    double sentence;
    for (int i = 1; i <= N; i++)
    //Change < to <=
    {
        up = Math.Pow(X, i);
        //This is a for loop i created to get the factorial of any number, sometimes creating your own functions may be worth it
        for (int a = N, a > 0, a--)
        {
         //Function of this Loop : multiply the value of the denominator by its value - 1 to get the factorial of  the number
            down *= a;
        } 
        sentence = up / down;
        sum += sentence;
    }
    Console.WriteLine("The Sum is : " + sum);
    
