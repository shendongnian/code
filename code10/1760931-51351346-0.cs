    public struct MyType
    {
        public string Area { get; set; }
        public string Name { get; set; }
    }
    class Class1
    {
        public MyType Get(int id)
        {
            var hisGrade = (from p in ctx.Students
                            where p.StudentID == id
                            select new MyType{ Area = p.Grade.Section, Name = p.Grade.GradeName }).FirstOrDefault();
            return hisGrade;
        }
    }
