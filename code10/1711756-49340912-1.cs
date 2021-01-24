    public class Student
    {
        private static Student instance = null;
        private static readonly object locker = new object();
        public static Student Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Student();
                    }
                    return instance;
                }
            }
        }
        public void SomeMethod()
        {
        }
    }
