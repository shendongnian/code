    [TestMethod]
    public void test_sum_string()
    {
        string cpu_usage = @"cpu  16272 1158 46722 553911117 31493 0 158 0 0 0
        cpu0 2099 184 5874 34608555 408 0 56 0 0 0 
        cpu1 586 0 1544 34624437 314 0 12 0 0 0
        cpu2 1162 0 3184 34618796 1854 0 8 0 0 0
        cpu3 609 4 1594 34624014 411 0 3 0 0 0";
    
        string[] cpu_usage_arr = cpu_usage.Split('\n');
        for (int i = 0; i < cpu_usage_arr.Length; i++)
        {
              string cpu_usage_row = cpu_usage_arr[i];
              string[] cpu_usage_row_split = cpu_usage_row.Split(' ');
              var totalUsage = cpu_usage_row_split.Sum(x => AsInt(x));
              Console.WriteLine(totalUsage);
        }
    }
           
    private static int AsInt(string value)
    {
          int i = 0;
          bool b = int.TryParse(value, out i);
          return b ? i : 0;
    }
