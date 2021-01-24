    var a = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    SerialNumber = 1,
                    ID = "AB01",
                    FirstName = "Ala",
                    MiddleName = "b",
                    LastName = "ala"
                },
                new EmployeeDto()
                {
                      SerialNumber = 2,
                    ID = "AB02",
                    FirstName = "Ala",
                    MiddleName = "b",
                    LastName = "ala"
                },new EmployeeDto()
                {
                      SerialNumber = 3,
                    ID = "AB03",
                    FirstName = "Ala",
                    MiddleName = "b",
                    LastName = "ala"
                }
            };
            // biggestIdAsInt = 230 a.max returns the max value after the calculations 
            var biggestIdAsInt = a.Max(employee => Encoding.ASCII.GetBytes(employee.ID) // get Employee Id as byte array
            .Sum(b => b)); // summ the bytes for each employee 
            // 230
           
   
    var substractedNumberFromBiggestId = Regex.Match(a.FirstOrDefault(x => x.ID.ToCharArray().Sum(y => y) == biggestIdAsInt).ID, @"\d+").Value;
            Console.WriteLine(substractedNumberFromBiggestId);
