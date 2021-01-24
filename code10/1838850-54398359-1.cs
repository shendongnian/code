    public Student(string title, string name, string surname, string dob, string degreename = "") : base(title, name, surname, dob)
    {
        var Studentslist = new List<string>();
        if (stucount == 0) // if this is the very first student, create the list Studentslist for the very first time AND and the very first student to the list
        {
            stucount++;
            Studentslist.Add(this.getStuIDtitleNameSurname()); // this part goes OK, however if I try access this from Main, it will throw System.NullReferenceException
        }
        else
        {
            stucount++;
            var studat = this.getStuIDtitleNameSurname();
            Studentslist.Add(studat); //when I add a another student in Main (I only have one Main, that is in the Program.cs) the code breaks here. 
        }
    }
