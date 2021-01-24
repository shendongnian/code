    public IList<AnswerRequestModel> SortAnswersByPriority(IList<AnswerRequestModel> answers)
    {
        if (!answers.Any()) return answers;
        var chosenAnswers = answers.Where(m => m.Active).ToList();
        // If we have no chosen answers, then just do a default sort by priority
        if (!chosenAnswers.Any()) return answers.OrderBy(m => m.Question.Priority).ThenBy(m => m.Priority).ToList();
        var sortedAnswers = answers.OrderBy(a => 1);
        var questionIds = answers.GroupBy(m => m.Question.Id).Select(m => m.Key).ToList();
        foreach(var questionId in questionIds)
        {
            var questionAnswers = answers.Where(m => m.Question.Id == questionId).ToList();
            if (!questionAnswers.Any()) continue;
            var lowestPriority = questionAnswers.OrderByDescending(m => m.Priority).First().Priority;
            var chosenQuestionAnswers = answers.Where(m => m.Active).ToList();
            var count = chosenQuestionAnswers.Count;
            var ordered = questionAnswers.OrderBy(a => 1);
            // Sort by our chosen answers first, then by answer priority
            if (chosenQuestionAnswers.Any(m => m.Priority.Equals(lowestPriority)))
            {
                switch (count)
                {
                    case 1:
                        ordered = ordered.OrderByDescending(m => m.Priority);
                        break;
                    default:
                        ordered = ordered.OrderByDescending(m => m.Active).ThenByDescending(m => m.Priority);
                        break;
                }
            } else
            {
                ordered = ordered.OrderByDescending(m => m.Active).ThenBy(m => m.Priority);
            }
            var questionAnswerIds = ordered.Select(m => m.Id).ToList();
            sortedAnswers = sortedAnswers.ThenBy(m => questionAnswerIds.IndexOf(m.Id));
        }
        // Once we have sorted by our answer priority, do a final sort on question priority and return the list
        return sortedAnswers.OrderBy(m => m.Question.Priority).ToList();
    }
