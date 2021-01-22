    Dictionary<string, Dictionary<string, double>> temphours =
    (
      from user in hours
      let department = GetDepartment(user.Key)
      from customerReport in user.Value
      group customerReport by department
    )
    .ToDictionary(
      g => g.Key,
      g => g.GroupBy(rep => rep.Key).ToDictionary
      (
        g2 => g2.Key,
        g2 => g2.Sum(rep => rep.Value)
      )
    );
