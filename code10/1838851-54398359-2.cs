    public Student(string title, string name, string surname, string dob, string degreename = "") 
    : base(title, name, surname, dob)
    {
        //Method level scope
        var Studentslist = new List<string>();
        if (stucount == 0) /
        {
            stucount++;
            Studentslist.Add(this.getStuIDtitleNameSurname()); 
        }
        else
        {
            stucount++;
            var studat = this.getStuIDtitleNameSurname();
            Studentslist.Add(studat);
        }
    }
