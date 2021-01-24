    public static void CombineList()
    {
        List<string> cols = new List<string> {"col1", "col2", "col3", "col4", "col5", "col6", "col7"};
        List<string> nums = new List<string> { "10", "20", "50"};
        int numsCount = nums.Count;
        List<string> comb = new List<string>();
        for(int i = 0; i < cols.Count; i++)
        {
            string s = $"{cols[i]}: {nums[i%numsCount]}";
            Debug.WriteLine(s);
            comb.Add(s);    
        }
        Debug.WriteLine("done");
    }
    col1: 10
    col2: 20
    col3: 50
    col4: 10
    col5: 20
    col6: 50
    col7: 10
