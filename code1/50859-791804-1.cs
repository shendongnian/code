    List<Question> questions = (from xml in xdoc.Descendants("question")
                                        select new Question
                                        {
                                            text = xml.Element("text").Value,
                                            answers =
                                                (from anwsers in xml.Descendants("answer")
                                                 select new Answer
                                                 {
                                                     Content = anwsers.Element("v").Value
                                                 }
                                                ).ToList()
                                        }).ToList();
