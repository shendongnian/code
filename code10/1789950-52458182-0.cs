       var jsonData = System.IO.File.ReadAllText(jsonFile);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();
            // Add any new employees
            employeeList.Add(new Student()
            {
                Rollnumber = 1,
                StudentName = "Paja1",
                Subject = new Subject
                {
                    Id = 1,
                    Name = "Sub1"
                }
            });
            employeeList.Add(new Student()
            {
                Rollnumber = 1,
                StudentName = "Pera1",
                Subject = new Subject
                {
                    Id = 1,
                    Name = "Sub1"
                }
            });
            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList,Formatting.Indented);
            System.IO.File.WriteAllText(jsonFile, jsonData);
