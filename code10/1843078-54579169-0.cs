    //need to update the submission answers FormSubmissionId            
    foreach (FormSubmissionAnswer answer in submissionAnswers)
        answer.FormSubmissionId = submission.Id; //erroring here
    base.SubscriptionDB.FormSubmissionAnswers.InsertAllOnSubmit(submissionAnswers);
    base.SubscriptionDB.SubmitChanges();
