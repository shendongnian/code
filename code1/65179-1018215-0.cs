    Dictionary<double, string> dic = new Dictionary<double, string>();
    double highest = double.MinValue;
    string result = null;
    foreach(double d in dic.keys)
    {
       if(d > highest)
       {
          result = dic[d];
          highest = d;
       }
    }
