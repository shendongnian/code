    var result = dbContext.Questions.GroupJoin(  // GroupJoin Questions with Upvotes
         dbContext.Upvotes,
         question => question.Id,                // from every question take the Id,
         upVote => upvote.QuestionId,            // from every upvote take the QuestionId,
         (question, upvotes) => new              // for every question with its matching Upvotes
         {                                       // make one new object
              Id = question.Id,
              Text = question.QuestionTxt,
              UpvoteCount = upvotes.Count(),
         });
