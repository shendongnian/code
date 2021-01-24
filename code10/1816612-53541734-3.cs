    string[] list = TextBox1.Text.Split(new string[] { "," }, 
      StringSplitOptions.RemoveEmptyEntries);
    IEnumerable<IGrouping<int, int>> modes = list.GroupBy(v => v);
    IEnumerable<IGrouping<int, IGrouping<int, int>>> groupedModes = modes.GroupBy(v => v.Count());
    var sortedGroupedModes = groupedModes.OrderByDescending(g => g.Key).ToList();
                                  
    TextBox2.Text = string.Join(" ", sortedGroupedModes[0].Select(x => x.Key)));
