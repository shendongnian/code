    var employeeList = delimitedByLine.Select(x=>
    {
        string[] delimitedByComma = x.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        return new Employee()
        {
           DomainName = delimitedByComma[0],
           Name = delimitedByComma[1],
           AccountName = delimitedByComma[2],
           GivenName = delimitedByComma[3],
           Surname = delimitedByComma[4],
           Email = delimitedByComma[5],
           PhysicalDeliveryOfficeName = delimitedByComma[6]
        }
    }).ToList();;
