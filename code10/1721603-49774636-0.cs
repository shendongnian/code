    class Program
        {
            static List<Teacher> teachers = new List<Teacher>();
            static void Main(string[] args)
            {
                connectDbRead();
                searchTeacher();
                Console.ReadLine();
            }
            public static void connectDbRead()
            {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP;Database=Test;Trusted_Connection=true"))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM TEACHERS", conn);
                    
                    teachers.Clear();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teachers.Add(new Teacher
                            {
                                Name = (string)reader["NAME"],
                                FamilyName = (string)reader["FAMILY_NAME"],
                                Age = (int)reader["AGE"]
                            });
                        }
                    }
                }
            }
            public static void searchTeacher()
            {
                string teacherName = "";
                Console.WriteLine("Who do you want to find. Write his name: ");
                teacherName = Console.ReadLine();
    
                var foundTeachers = teachers.FindAll(x => x.Name == teacherName);
    
                Console.WriteLine("List Of ELements!");
                foreach (Teacher t in foundTeachers)
                {
                    Console.WriteLine(String.Format("{0} | {1} | {2}", t.Name, t.FamilyName, t.Age));
                }
            }
        }
        public class Teacher
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public string FamilyName  { get; set; }
        } 
