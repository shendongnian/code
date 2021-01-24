    public static class ExtensionClass
    {
        public static Student CopyAsNewObject(this Student std)
        {
            var newStudent = new Student()
            {
                FirstName = std.FirstName,
                LastName = std.LastName
            };
            return newStudent;
        }
    }
        static void Main(string[] args)
        {
            var s1 = new Student();
            var s2 = s1.CopyAsNewObject();
        }
