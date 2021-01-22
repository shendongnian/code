    List<string> list = [your strings]
    List<double> newList = new List<double>();
    for(int i = 0; i < list.Count; i++)
    {
      double d = 0;
      if(!double.TryParse(list[i], d)) //Error
      newList.Add(d);
    }
