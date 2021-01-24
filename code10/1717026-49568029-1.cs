    static void Main(string[] args)
    {
        List<StudentInfo> studentInfo = new List<StudentInfo>();
    
        string input = "(LIST(LIST 'Abbott 'Ashley 'J ) '8697387888 'ajabbott@mail.university.edu 2.3073320999676614 )" + Environment.NewLine +
        "(LIST(LIST 'Abbott 'Bradley 'M ) 'NONE 'bmabbott@mail.university.edu 3.1915725161177115 )" + Environment.NewLine +
        "(LIST(LIST 'Abbott 'Ryan 'T ) '8698689793 'rtabbott@mail.university.edu 3.448215586562192 )";
    
        string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    
        if (lines != null && lines.Count() > 0)
        {
    		foreach (var line in lines)
    		{
    			var data = line.Replace("(LIST(LIST ", string.Empty)
    				.Replace(")", string.Empty)
    				.Replace("'", string.Empty)
    				.Trim()
    				.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    			if (data != null && data.Count() > 0)
    			{
    				studentInfo.Add(
    					new StudentInfo()
    					{
    						Name = data[0] + " " + data[1] + " " + data[2],
    						Number = data[3],
    						Email = data[4],
    						GPA = Convert.ToDouble(data[5])
    					});
    			}
    		}
        }
    
        // GET STUDENTS WHO GOT GPA > 3  (LINQ QUERY)
        if (studentInfo.Count > 0)
        {
    		var gpaGreaterThan3 = studentInfo.Where(s => s.GPA >= 3).Select(s => s).ToList();
    
    		if (gpaGreaterThan3 != null && gpaGreaterThan3.Count > 0)
    		{
    			// LOOP gpaGreaterThan3 TO PRINT STUDENT DATA
    			foreach (var stud in gpaGreaterThan3)
    			{
    				Console.WriteLine("Name: " + stud.Name);
    				Console.WriteLine("Number: " + stud.Number);
    				Console.WriteLine("Email: " + stud.Email);
    				Console.WriteLine("GPA: " + stud.GPA);
    				Console.WriteLine(string.Empty);
    			}
    		}
        }
    
        Console.ReadLine();
    }
