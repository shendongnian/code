       private void button1_Click(object sender, EventArgs e)
        {
          List<Answer> list = GetAnswers();
    
          var dict = (from a in list
                     group a by a.QuestionID into grp
                     from g in grp
                     where g.Version == grp.Max(m => m.Version)
                     select new { id = g.QuestionID, q = g }).ToDictionary( o => o.id, o => o.q);
    
          StringBuilder sb = new StringBuilder();
          foreach (var elem in dict)
          {
            sb.AppendLine(elem.Key.ToString() + "-" + elem.Value.Version.ToString());
          }
          MessageBox.Show(sb.ToString());
        }
    
        private List<Answer> GetAnswers()
        {
          List<Answer> result = new List<Answer>();
          result.Add(new Answer() { ID = 1, QuestionID = 1, Version = 1 });
          result.Add(new Answer() { ID = 2, QuestionID = 1, Version = 2 });
          result.Add(new Answer() { ID = 3, QuestionID = 1, Version = 3 });
          result.Add(new Answer() { ID = 4, QuestionID = 2, Version = 1 });
          result.Add(new Answer() { ID = 5, QuestionID = 2, Version = 2 });
          result.Add(new Answer() { ID = 6, QuestionID = 2, Version = 3 });
          result.Add(new Answer() { ID = 7, QuestionID = 3, Version = 1 });
          result.Add(new Answer() { ID = 8, QuestionID = 3, Version = 2 });
          result.Add(new Answer() { ID = 9, QuestionID = 3, Version = 3 });
          result.Add(new Answer() { ID = 10, QuestionID = 3, Version = 4 });
          return result;
        }
