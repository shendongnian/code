    static Employee[] GetEmployeeData(int size)
    {
            Employee[] E = new Employee [size];
            for (int i = 0; i < size; i++)
            {
                E[i] = new Employee();
                Console.Write("Code: ");
                E[i].code = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                E[i].salary = float.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                E[i].bonus = float.Parse(Console.ReadLine());
                Console.Write("Deduction: ");
                E[i].deduction = float.Parse(Console.ReadLine());
            }
            return E;
        }
