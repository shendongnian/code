    public bool PopulateStudents(string path)
    {
        theStudentList = new List<Student>();
        bool flag = false;
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
                string[] strArray = strArrayList[index1];
                // below that, what makes you believe strArray's length is >= 3 ?
                Student student = new Student(strArray[0], strArray[1], strArray[2]);
                int index2 = 3;
                while (index2 < strArray.Length)
                {
                    // here index2 will be < strArray.Length, but index2+1 might be ==
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
        }
        return flag;
    }
