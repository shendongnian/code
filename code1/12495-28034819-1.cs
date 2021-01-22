    public interface IStudentFriend
    {
        Student Stu { get; set; }
        double GetGPS();
    }
    public class Student
    {
        // this is private member that I expose to friend only
        double GPS { get; set; }
        public string Name { get; set; }
        PrivateData privateData;
        public Student(string name, double gps) => (GPS, Name, privateData) = (gps, name, new PrivateData(this);
     
        // No one can instantiate this class, but Student
        // Calling it is possible via the IStudentFriend interface
        class PrivateData : IStudentFriend
        {
            public Student Stu { get; set; }
            public PrivateData(Student stu) => Stu = stu;
            public double GetGPS() => Stu.GPS;
        }
        // This is how I "mark" who is Students "friend"
        public void RegisterFriend(University friend) => friend.Register(privateData);
    }
    public class University
    {
        var studentsFriends = new List<IStudentFriend>();
        public void Register(IStudentFriend friendMethod) => studentsFriends.Add(friendMethod);
        public void PrintAllStudentsGPS()
        {
            foreach (var stu in studentsFriends)
                Console.WriteLine($"{stu.Stu.Name}: stu.GetGPS()");
        }
    }
    public static void Main(string[] args)
    {
        var Technion = new University();
        var Alex     = new Student("Alex", 98);
        var Jo       = new Student("Jo", 91);
    
        Alex.RegisterFriend(Technion);
        Jo.RegisterFriend(Technion);
        Technion.PrintAllStudentsGPS();
        Console.ReadLine();
    }
