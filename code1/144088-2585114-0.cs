    if (!string.IsNullOrEmpty(itemOne.Text) && !string.IsNullOrEmpty(itemTwo.Text))
    {
        uint itemOneComparison = uint.Parse(itemOne.Text);
        uint itemTwoComparison = uint.Parse(itemTwo.Text);
    
        comparison = itemOneComparison.CompareTo(itemTwoComparison);
    }
    else if (!string.IsNullOrEmpty(itemOne.Text)
    {
        comparison = -1;
    }
    else
    {
        comparison = 1;
    }
