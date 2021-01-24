    public void SetExamStart(Exam exam, List<ExamCandidate> examCandidates)
    {
        DateTime startTime = _timeService.GetCurrentDateTime();
        examCandidates.ForEach(ec =>
        {
           ExamPaper examPaper = ec.ExamPaper;
           if (!examPaper.ExamDuration.HasValue)
           {
              return;
           }
           Int32 examPaperDuration = examPaper.ExamDuration.Value;
           DateTime scheduledFinish = startTime.AddMinutes(examPaperDuration);
           ec.ScheduledFinish = scheduledFinish;
           _work.ExamCandidateRepository.Update(ec);
        });
        exam.ExamStarted = startTime;
       _work.ExamRepository.Update(exam);
    }
