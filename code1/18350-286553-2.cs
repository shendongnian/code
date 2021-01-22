            DateTime minDate = new DateTime(2000,1,1);
            var query = from line in ReadLines(file)
                        let tokens = line.Split('\t')
                        let person = new
                        {
                            Forname = tokens[0],
                            Surname = tokens[1],
                            DoB = DateTime.Parse(tokens[2])
                        }
                        where person.DoB >= minDate
                        select person;
            foreach (var person in query)
            {
                Console.WriteLine("{0}, {1}: born {2}",
                    person.Surname, person.Forname, person.DoB);
            }
