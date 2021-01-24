    using (StreamReader reader = new StreamReader("/Users/jvb/Desktop/Test/Test/Students.txt"))
                {
        while(!streamReader.EndOfStream)
     {
                  
    line = reader.ReadLine();
                        var s = line.Split(',');
                        int id = int.Parse(s[0]);
                        int houseNo = int.Parse(s[3]);
                        var status = int.Parse(s[7]);
                        Student sData = new Student(id, s[1], s[2], houseNo, s[4], s[5], s[6], (StudentStatus)status);
                        AddStudent(sData);
                }
    }
