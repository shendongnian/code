    string subject = SubjectTextBox.Text;
    string body = BodyTextBox.Text;
    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    foreach (string to in toList)
    {
      Task.Factory.StartNew(() => SendMail(from, "password", to, subject, body))
          .ContinueWith(task =>
          {
            if (task.Result)
            {
              OutPutTextBox.appendText("Sent to: " + to); 
            }
            else
            {
              OutPutTextBox.appendText("Failed to: " + to); 
            }
          }), ui);
    }
