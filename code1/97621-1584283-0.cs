    class Professor
    {
        string profid;
        public string ProfessorID
        {
            get { return profid; }
            set { profid = value; }
        }
        student st;
        public student Student { // New property
            get { return st; }
            set { st = value; }
        }
    }
    class student
    {
        string name;
        string id;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string StudentID
        {
            get { return id; }
            set { id = value; }
        }
    }
    public void GetDetails(){
        Professor prf=new Professor(){ ProfessorID="1", Student = new student()};
    }
