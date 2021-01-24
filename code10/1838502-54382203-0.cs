    var words = data.Split();
    int i;
    List<int> integers = new List<int>();
    foreach(var s in words)
    {
      if (int.TryParse(s, out i)) {integers.Add(i);}
    }
    // now you have a list of integers
    // if using decimal, use decimal instead of integer
