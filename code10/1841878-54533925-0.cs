    Student student = null;
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            switch (reader.Name)
            {
                case "student":
                    student = new Student();
                    Students.Add(student);
                    break;
                case "name":
                    student.name = reader.ReadString();
                    //Console.WriteLine(student.name);
                    break;
                case "semester":
                    student.semester = reader.ReadString();
                    break;
            }
        }
    }
