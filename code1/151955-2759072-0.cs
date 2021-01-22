    public void examsCallback(IAsyncResult result)
    {
        try
        {
            EntityList<ExamEntity> examList = ((IExamService) result.AsyncState).EndGetAllExams(result);
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                foreach (ExamEntity exam in examList)
                {
                    Exams.Add(exam);
                }
                ItemCount = Exams.Count;
                TotalItemCount = Exams.ItemCount;
            });
        }
        catch (Exception ex)
        {
            ErrorHandler.Handle(ex);
        }
    }
