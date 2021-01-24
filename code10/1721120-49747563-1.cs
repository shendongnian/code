    public class Student
    {
       private string name;
       private School school; //which represent the school of the student
       private List<Class> classes; //Represent all the class he attends
    }
    public class Class
    {
       private string name;
       private List<Student> students; //Represent all the students attending the class
    }
