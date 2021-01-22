    String input = "23 34 1 3 100 56 h45 43 56 4 87 6 89 9";
    Int32 dummy;
    List<Int32> result = new List<Int32>();
    foreach (String item in input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    {
        Int32 number;
        if (Int32.TryParse(item, out number))
        {
            result.Add(number);
        }
        else
        {
            // Handle invalid items.
        }
    }
