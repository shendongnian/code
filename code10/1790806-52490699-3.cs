        static void Main(string[] args)
        {
            var s1 = new Student();
            var s2 = ClassHelper.CopyObject(s1);
        }
        public static class ClassHelper
        {
            public static Student CopyObject(Student std)
            {
                var newStudent = new Student()
                {
                    FirstName = std.FirstName,
                    LastName = std.LastName
                };
                return newStudent;
            }
        }
