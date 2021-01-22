            var qry = from cls in doc.Root.Elements("class")
                      from student in cls.Elements("student")
                      from question in student.Elements("question")
                      from skill in question.Elements("skill")
                      group skill by new
                      {
                          Student = (int)student.Attribute("id"),
                          Skill = (string)skill.Attribute("id")
                      } into grp
                      orderby grp.Key.Student, grp.Key.Skill
                      select new {grp.Key.Student, grp.Key.Skill, Count = grp.Count()};
            foreach (var row in qry)
            {
                Console.WriteLine("{0}\t{1}\t{2}", row.Student, row.Skill, row.Count);
            }
