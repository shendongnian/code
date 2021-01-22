        List<student> ExistingStudents = new List<student>();
        List<student> LinkedStudents = new List<student>();
        ExistingStudents.Add(new student {id=1, name="joe"});
        ExistingStudents.Add(new student { id = 2, name = "beth" });
        ExistingStudents.Add(new student { id = 3, name = "sam" });
        LinkedStudents.Add(new student { id = 2, name = "beth" });
        var students = from stud in ExistingStudents
                        where !(LinkedStudents.Select(x => x.id).Contains(stud.id))
                        select stud;
        foreach(student s in students)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("id: {0}, name: {1}", s.id, s.name));
        }
