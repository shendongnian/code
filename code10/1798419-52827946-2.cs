    // gather the unique question IDs
    var questionIds = rows.Select(r => r.Question).ToList();
    // query the database for all the questions referenced in the rows list
    // and put the question texts in a dictionary by keyed by question id
    var questionDict = _context.Questions
                               .Where(q => questionIds.Contains(q.Id))
                               .ToDictionary(q => q.Id, q => q.Text);
    // gather the unique answer IDs
    var answerIds = rows.Where(r => r.Answer != null && r.Answer.Length == 32)
                        .Select(r => r.Answer)
                        .Distinct()
                        .ToList();
    // query the database for all the answers referenced in the rows list
    // and put the answer values in a dictionary by keyed by answer id
    var answerDict = _context.OfferedAnswers
                             .Where(a => answerIds.Contains(a.Id))
                             .ToDictionary(a => a.Id, a => a.Value);
    // now we can loop over the rows and look up the question/answer text in the dictionaries
    foreach (var row in rows)
    {
        string questionText = null;
        if (!questionDict.TryGetValue(row.Question, out questionText))
            questionText = row.Question;  // if not found, use the question ID instead
        string answerValue = null;
        if (row.Answer != null && !answerDict.TryGetValue(row.Answer, out answerValue))
            answerValue = row.Answer;  // if not found use the answer value from the row instead
        Console.WriteLine(questionText + " -- " + answerValue);
    }
