    latestVersionAnswers = answers
      .GroupBy(e => e.Question.ID)
      .ToDictionary(
        g => g.Key,
        g => g.OrderByDescending(e => e.Version).First()
      );
