        public bool PopulateStudents(string path)
    {
        theStudentList = new List<Student>();
        bool flag = false; 
	    // EDIT: NEW VARIABLE int lineCounter declared and initialized before try block so it remains in scope when the catch block is called
	    int counter = 0;
        try
        {
            List<string[]> strArrayList = new List<string[]>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(',');
                    strArrayList.Add(strArray);
                }
            }
            for (int index1 = 0; index1 < strArrayList.Count; ++index1)
            {
		        // EDIT: UPDATE lineCounter
		        ++lineCounter;
                string[] strArray = strArrayList[index1];
                Student student = new Student(strArray[0], strArray[1], strArray[2]);
                int index2 = 3;
                while (index2 < strArray.Length)
                {
                    student.EnterGrade(int.Parse(strArray[index2]), int.Parse(strArray[index2 + 1]));
                    index2 += 2;
                }
                student.CalGrade();
                theStudentList.Add(student);
            }
        }
        catch (Exception e)
        {
            flag = true;
            Console.WriteLine(e);
		    // EDIT: PRINT CURRENT LINE
		    Console.WriteLine(“error at line in file = “ + lineCounter);
        }
        return flag;
    }
