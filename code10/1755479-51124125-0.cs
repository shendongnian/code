    foreach(string[] lineItem in storedCSVData)
    {
        string fullName = lineItem[0] + " " + lineItem[1];
        
        //Get student instance instead of index, since you would use it anyway
        Student student = Students.FirstOrDefault(s => s.GetFullName().Contains(fullName));
        //If there is no result, FirstOrDefault returns 'null'
        if(student != null)
        {
            //Add using refernce instead of using index
            student.SubjectScore.Add(
                lineItem[4], 
                Convert.ToDouble(lineItem[5]));
            continue;
        }                         
        Student storedStudent = new Student(lineItem[0],
                                            lineItem[1],
                                            lineItem[2] == "Yes" ? true : false,
                                            Convert.ToInt32(lineItem[3]));
        Students.Add(storedStudent);
    }
