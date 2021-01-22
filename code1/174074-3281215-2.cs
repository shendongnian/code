    string subject = SubjectTextBox.Text;
    string body = BodyTextBox.Text;
    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    List<Task> mails = new List<Task>();
    foreach (string to in toList)
    {
      string target = to;
      var t = Task.Factory.StartNew(() => SendMail(from, "password", target, subject, body))
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
          }, ui);
      mails.Add(t);
    }
    Task.ContinueWhenAll(mails.ToArray(), _ => { /* do something */ });
