    private List<CheckBox> _checkBoxes;
    private void Test()
    {
        Init();
        List<CheckBox> checkedCheckBoxes = _checkBoxes.Where(cb => cb.Checked == true).ToList();
        StringBuilder str = new StringBuilder();
        string delimiter = String.Empty;
        for (int i = 0; i < checkedCheckBoxes.Count; i++)
        {
            str.Append(delimiter);
            str.Append(checkedCheckBoxes[i].Name);
            if (i != checkedCheckBoxes.Count)
            {
                if (i == checkedCheckBoxes.Count - 2)
                    delimiter = " and ";
                else
                    delimiter = ", ";
            }
        }
        Console.WriteLine(str.ToString());
        Console.ReadLine();
    }
    private void Init()
    {
        _checkBoxes = new List<CheckBox>();
        string[] days = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        Random r = new Random();
        foreach (string day in days)
        {
            CheckBox cb = new CheckBox();
            cb.Name = day;
            cb.Checked = Convert.ToBoolean(r.Next(0, 2));
            _checkBoxes.Add(cb);
        } 
    }
