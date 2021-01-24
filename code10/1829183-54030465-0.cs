    int result = RecursiveCheck(f.Controls);
    if(result > 0)
        Console.WriteLine("Something is not checked");
    int RecursiveCheck(Control.ControlCollection col)
    {
        int count = 0;
        foreach(Control c in col)
        {
            if (c.Controls.Count > 0)
            {
                count += c.Controls.OfType<CheckBox>().Count(x => !x.Checked);
                count += RecursiveCheck(c.Controls);
            }   
        }
        return count;
    }
