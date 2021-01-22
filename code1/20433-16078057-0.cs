    enum Commands
    {
        StudentDetail
    }
    public static class Quires
    {
        public static Dictionary<Commands, String> quire
            = new Dictionary<Commands, String>();
        static Quires()
        {
            quire.add(Commands.StudentDetail,@"SELECT * FROM student_b");
        }
    }
