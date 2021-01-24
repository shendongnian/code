    private void button4_Click(object sender, EventArgs e)
            {
                const string demostring = "1,2,3,4,5,6";
                var tokens = demostring.Split(',');
                var nums = new List<int>();
                foreach (var s in tokens)
                    if (int.TryParse(s, out var oneNum))
                        nums.Add(oneNum);
    
                var result1 = AddIntegers(nums);
            }
            public static int AddIntegers(List<int> restnum)
            {
                var result = 0;
    
                foreach (var temp in restnum)
                    result += temp;
    
                return result;
            }
