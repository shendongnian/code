       public dynamic Get(int id)
        {
            var hisGrade = (from p in ctx.Students
                            where p.StudentID == id
                            select new { area = p.Grade.Section, name = p.Grade.GradeName }).FirstOrDefault();
            return hisGrade;
        }
