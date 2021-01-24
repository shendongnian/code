    string s = "select * Question, CLO, Question_Type FROM QuestionBank WHERE (Subject = '" + sub + "') AND (chapter = '" + chapter + "') AND (Question_Type = '" + qt.name + "') ORDER BY RAND() LIMIT = '" + qt.numOfType;
                    SqlCommand cmd = new SqlCommand(s, con);
                    SqlDataReader dr;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    while (dr.Read())
                    {
                        string ques = dr["Question"].ToString();
                        string questype = dr["Question_Type"].ToString();
                        string quesCLO = dr["CLO"].ToString(); 
                        QuestionList.Add(new Gene (ques, questype, quesCLO));
                    }
                     con.Close();
                     var geneArray = QuestionList.ToArray()
                   }
