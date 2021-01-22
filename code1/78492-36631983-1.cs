    class Program
    {
        static void Main(string[] args)
        {
            string[] emp_names = File.ReadAllLines("D:\\Employee Names.txt");
            List<string> newemp1 = new List<string>();
            for (int i = 0; i < emp_names.Length; i++)
            {
                newemp1.Add(emp_names[i]);
            }
            for (int i = 0; i < emp_names.Length; i++)
            {
                List<string> temp = new List<string>();
                int duplicate_count = 0;
                for (int j = newemp1.Count - 1; j >= 0; j--)
                {
                    if (emp_names[i] != newemp1[j])
                        temp.Add(newemp1[j]);
                    else
                    {
                        duplicate_count++;
                        if (duplicate_count == 1)
                            temp.Add(emp_names[i]);
                    }
                }
                newemp1 = temp;
            }
            string[] newemp = newemp1.ToArray();
            Array.Sort(newemp);
            File.WriteAllLines("D:\\Employee Names.txt", newemp);
            Console.ReadLine();
        }
    }
