    string[] list = TextBox1.Text.Split(new string[] { "," }, 
      StringSplitOptions.RemoveEmptyEntries);
    int[] numbers = new int[list.Length];
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = Convert.ToInt32(list[i].Trim());
    }
    IEnumerable<int> modes = numbers.GroupBy(v => v)
                                    .OrderByDescending(g => g.Count());
    Console.WriteLine(modes[0]);
    Console.WriteLine(modes[1]);
