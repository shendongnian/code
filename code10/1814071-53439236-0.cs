    Console.WriteLine("Enter two Numbers to start the Equation (X=Number , N=Power)" + "");
    int X = int.Parse(Console.ReadLine());
    int N = int.Parse(Console.ReadLine());
    double sum = 0;
    double up = 1;
    int down = 1;
    
    
        double sentence;
        for (int i = 1; i < N; i++)
        {
        up = Math.Pow(X, i);
        down = N * i;
        sentence = up / down;
        sum += sentence;
        }
        Console.WriteLine("The Sum is : " + sum);
