    public bool IsSame(List<double> list1, List<double> list2)
    {
      var firstNotSecond = list1.Except(list2).ToList();
      var secondNotFirst = list2.Except(list1).ToList();
      return !firstNotSecond.Any() && !secondNotFirst.Any();
    }
