                  Console.Write("Enter a month?: ");
                  var userMonth = (Console.ReadLine());
                  var months = GetMonths();
      
                  var result = months.Where(x => x.MonthNames.Any(y => y.Equals(userMonth))).ToList();
