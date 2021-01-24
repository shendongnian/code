    static IEnumerable<Employee> GetEmployeeData(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Employee e = new Employee();
            Console.Write("Code: ");
            e.code = int.Parse(Console.ReadLine());
            Console.Write("Salary: ");
            e.salary = float.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            e.bonus = float.Parse(Console.ReadLine());
            Console.Write("Deduction: ");
            e.deduction = float.Parse(Console.ReadLine());
            yield return e;
        }
    }
