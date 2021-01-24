    var result = testQ.GroupBy(question => question.QuestionId);
        // every group contains a sequence of questions with same questionId
        // select the ones with a null SelectedAnswerId and the ones with a non-null value
        .Select(group => new
        {
            NullSelectedAnswer = group
                .Where(group.SelectedAnswerId == null)
                .FirstOrDefault(),
            NonNullselectedAnswer = group
                .Where(group.SelectedAnswerId != null)
                .FirstOrDefault(),
        })
        // if there is any NonNullSelectedAnswer, take that one, otherwise take the null one:
        .Select(selectionResult => selectionResult.NonNullSelectedAnswer ??
                                   selectionResult.NullSelectedAnswer);
