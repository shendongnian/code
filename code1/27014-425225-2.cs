            var query2 = myElement.Descendants("ResultValue")
                .Select(rv => new 
                {
                    ResultValue = rv,
                    Age = rv.Ancestors("Age"),
                    Gender = rv.Ancestors("Gender"),
                    Result = rv.Ancestors("Result")
                })
                .Select(x => new XElement("Data",
                new XAttribute("ResultValue.Low", (int)x.ResultValue.Attribute("low")),
                new XAttribute("ResultValue.High", (int)x.ResultValue.Attribute("high")),
                new XAttribute("Age.Low", (int)x.Age.Attributes("low").Single()),
                new XAttribute("Age.High", (int)x.Age.Attributes("high").Single()),
                new XAttribute("Gender.Type", (string) x.Gender.Attributes("type").Single()),
                new XAttribute("Result.Description", (string) x.Result.Elements("Description").Single())
                ));
            foreach (XElement x in query2)
                Console.WriteLine(x);
