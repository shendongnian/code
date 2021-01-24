      string[] tests = new string[] {
        "11-04-2018",
        "11-Apr-2018",
      };
      var result = tests
        .Select(test => DateTime
          .ParseExact(test,
                      new string[] { "d-MM-yyyy", "d-MMM-yyyy" },
                      CultureInfo.GetCultureInfo("en-US"),
                      DateTimeStyles.AssumeLocal))
        .Select(date => date.ToString("dd : MM : yyyy"));
     Console.Write(string.Join(Environment.NewLine, result));
