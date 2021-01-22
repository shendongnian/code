    interface ICourse
    {
        string Name { get; set; }
    }
    interface ITeacher
    {
        string Name { get; set; }
    }
    interface IClassSession
    {
        ICourse Course { get; set; }
        ITeacher Teacher { get; set; }
        DateTime Scheduled { get; set; }
    }
    interface ITransactionalEntity
    {
        int ID { get; set; }
    }
    //sample class implementation
    class Teacher : ITeacher, ITransactionalEntity
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //implement interfaces
        public void Save(SqlTransaction tran)
        {
            if (this.ID > 0)
                //insert
            else
                //update
        }
    }
    
    class ClassSession : IClassSession, ITransactionalEntity
    {
        //implement interfaces
        public void Save(SqlTransaction tran)
        {
            this.Course.Save(tran);
            this.Teacher.Save(tran);
            if (this.ID > 0)
                //insert
            else
                //update
        }
    }
    ...
    List<IClassSession> list = new List<IClassSession>();
    ClassSession cs = new ClassSession();
    cs.Course = new Course(courseID);
    cs.Teacher = new Teacher(teacherID);
    classlist.Add(cs);
    SqlTransaction tran;
    ...
    foreach(IClassSession classsession in list)
        classsession.Save(tran);
    ...
