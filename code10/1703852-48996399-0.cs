		var num1 = Enumerable.Range(-10000, 20001).Reverse().ToList();
		var num2 = Enumerable.Range(-10000, 20001).Reverse().ToList();
        Action task1 = () => 
        {
            Console.WriteLine("Sum 2: {0}", num1.Sum());
        };
        Action task2 = () =>
        {
            num2.Sort();
            Console.WriteLine("Sum 3: {0}", num2.Sum());
        };
        Parallel.Invoke(task1, task2);
