    var qry = from cls in doc.Root.Elements("class")
              from student in cls.Elements("student")
              from question in student.Elements("question")
              from skill in question.Elements("skill")
              group skill by new
              {
                  Student = (int)student.Attribute("id"),
                  Skill = (string)skill.Attribute("id"),
                  Correct = (string)question.Attribute("correct") == "1"
              } into grp
              orderby grp.Key.Student, grp.Key.Skill
              select new {
                  grp.Key.Student,
                  grp.Key.Skill,
                  HasSkill = grp.Any(x=>grp.Key.Correct),
                  Count = grp.Count(x=>grp.Key.Correct)};
    
    foreach (var row in qry)
    {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            row.Student, row.Skill, row.HasSkill, row.Count);
    }
