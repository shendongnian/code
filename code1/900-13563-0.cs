    namespace Model
    {
        class Person
        {
            public string Title { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
        }
    }
    
    namespace View
    {
        static class PersonExtensions
        {
            public static string FullName(this Model.Person p)
            {
                return p.Title + " " + p.FirstName + " " + p.Surname;
            }
            
            public static string FormalName(this Model.Person p)
            {
                return p.Title + " " + p.FirstName[0] + ". " + p.Surname;
            }
        }
    }
