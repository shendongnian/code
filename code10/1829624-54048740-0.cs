    public void OutputGeneric(T[] employee, Func<T, dynamic> selector)
    {
        for (int i = 0; i < employee.Length; i++)
        {
            Console.Write("\n" + selector(employee[i]));//I still can't access to FullName and Salary
        }
    }
