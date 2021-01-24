            List<string> studentNames = new List<string>();
            studentNames.Add("Mark");
            studentNames.Add("Jamie");
            studentNames.Add("Chris");
            studentNames.Add("Mary");
            List<string> existingList = new List<string>()
            {
                "StudentName1, Math, History, English, Lunch",
                "StudentName2, History, Math, English, Lunch",
                "StudentName3, Math, Lunch, English, History",
                "StudentName4, English, History, Math, Lunch"
            };
            List<string> modifiedStudentList = existingList.Select(s => s.Replace(s.Split(',')[0], studentNames.ElementAt(existingList.IndexOf(s)))).ToList();
