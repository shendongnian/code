    Form form = GetForm(submission.FormId.ToString());
            //set submission values
            submission.FormTitle = form.Title1;
            submission.DateSubmitted = DateTime.Now;
            if (CustomerId > 0)
                submission.PSMCustomerId = CustomerId;
            submission.CustomerName = CustomerName;
            base.SubscriptionDB.FormSubmissions.InsertOnSubmit(submission);
            
            //need to update the submission answers FormSubmissionId            
            foreach (FormSubmissionAnswer answer in submissionAnswers)
                submission.FormSubmissionAnswers.Add(answer); 
       
            base.SubscriptionDB.SubmitChanges();
