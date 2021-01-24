    public int StudentCount => Students.Count;
    public List<string> Students => {get; set;}
    public Student() {
       Students = new List<string>();
    }
    public Student(string title, string name, string surname, string dob, string degreename = "") 
    : base(title, name, surname, dob)
    {
        Studentslist.Add(this.getStuIDtitleNameSurname()); 
    }
