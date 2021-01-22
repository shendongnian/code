    foreach (XElement student in students)
            {
                currentStudentId = student.Attribute("id").ToString();
                Console.WriteLine(currentStudentId);
                //this code chunk below doesn't work!
                IEnumerable<XElement> correctQuestions = student.Descendants("question").
                                      Where(q => q.Attribute("correct").Value == "1");                
                //Here you would do same for false answers
                //loop through correct answers
                foreach (XElement q in correctQuestions)
                {
                    IEnumerable<XElement> skills = q.Descendants("skill");
                    foreach (XElement s in skills)
                    {
                        //this prints "001.101.035.002.001" etc  
                        Console.WriteLine(s.Attribute("id").Value);
                    }
                }
                Console.WriteLine();
            }
