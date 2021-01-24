    FeedbackModel dbEntry = context.FeedbackModels.Include(s => s.FeedbackSteps).FirstOrDefault(a => a.FeedBackID == feedback.FeedBackID);
    if (dbEntry != null)
    {
          dbEntry.FeedBackID = feedback.FeedBackID;
          dbEntry.FBDate = feedback.FBDate;
          dbEntry.VideoStatus = feedback.VideoStatus;
          dbEntry.VideoDetail = feedback.VideoDetail;
          dbEntry.SupportPlanID = feedback.SupportPlanID;
          dbEntry.ActivityID = feedback.ActivityID;
          dbEntry.PITFeedBack = feedback.PITFeedBack;
          dbEntry.ClientID = feedback.ClientID;
          dbEntry.EmployeeID = feedback.EmployeeID;                   
          dbEntry.FeedbackStatus = feedback.FeedbackStatus;
          dbEntry.FeedbackSteps.Clear(); // First you have to clear the existing feedBackStatus
          foreach(FeedbackStep feedBackStep feedback.FeedbackSteps)
          {
             dbEntry.FeedbackSteps.Add(feedBackStep); // You have to add new and updated feedBackStatus here.
          }
    }
