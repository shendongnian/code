    var numbers = new List<int>();
    while (numbers.Count < userInput)
    {
        var tempRnd = rnd.Next(lowerBound, upperBound);
        if (!numbers.Contains(tempRnd))
        {
            numbers.Add(tempRnd);
        }
    }
    numbers.Sort();
    listView1.Items.Clear();
    listView1.Items.AddRange(numbers.Select(x => new ListViewItem { Text = x.ToString() }).ToArray());
    tbResult.Text = string.Join(", ", numbers);
            
    int i = 0;
    foreach (TextBox tb in this.Controls.OfType<TextBox>().Where(l => l.Name.StartsWith("GeneratedTB_")))
    {
        tb.Text = numbers[i].ToString();
        i++;
    }
