    static void Main(string[] args)
        {
            QA students = new QA();
            var studentList= s.GetStudents();  //you get all the students not you can iterate on this lidt
         foreach(var student in studentList)
         {
            //here you can access student property like
             Console.WriteLine(student.Name);  //I assume Name is a property of Student class
         }
        }
