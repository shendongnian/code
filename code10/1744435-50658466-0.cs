      enum WeekDay { Mon, Tues };
      Dictionary<string, WeekDay> dic = new Dictionary<string, WeekDay>();
      foreach (var v in WeekDay.Enumerate)  //this is not the correct syntax 
      {
          dic.Add(v.ToString(), v);
      }
