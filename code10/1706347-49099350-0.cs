    private IQueryable<Question> getQuestionAnswers(int n, int studentID)
    {
       return db.Question.Where(x => x.GroupId == studentId)
                          .OrderBy(x => Guid.NewGuid())
                          .Take(Convert.ToInt32(txtTedad.Text));
    }
    private int calculateStudentScore(int studentId)
    {
        int studentScore = 0;
        var studentAnswers = getQuestionAnswers(answerList.Length, studentId);
        
        for (int i = 0; i < answerList.Length; i++)
        {
           if (answerlist.Items[i].ToString() == data.Tolist[i].Id.ToString())
           {
                studentscore++;
           }
        }
        return studentScore;
    }
