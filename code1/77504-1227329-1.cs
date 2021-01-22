    IEnumerator<Question> myIterator = listOfStackOverFlowQuestions.GetEnumerator();
    while (myIterator.MoveNext())
    {
      Question q;
      q = myIterator.Current;
      if (q.Pertinent == true)
         PublishQuestion(q);
      else
         SendMessage(q.Author.EmailAddress, "Your question has been rejected");
    }
