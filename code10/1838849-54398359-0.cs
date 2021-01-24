    public Student(string title, string name, string surname, string dob, string degreename = "") : base(title, name, surname, dob)
    {
        //Method Level scope variable
        List<string> Studentslist = new List<string>();
   
        if (stucount == 0) 
        {
            stucount++;
    
            Studentslist.Add(this.getStuIDtitleNameSurname());     
        }
        else
        { 
            stucount++;
   
            string studat = this.getStuIDtitleNameSurname();
            Studentslist.Add(studat);  
        }
    }
