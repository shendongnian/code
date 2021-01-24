    IDictionary<Country, List<Answer>> answersDictionary = Database.Answer
            .GroupBy(a => a.Country).ToDictionary(d => d.Key, d => d.ToList());
    
    var answerDict = answersDictionary.OrderByDescending(d => d.Value.Count(a => a.State == AnswerState.Draft))
                                      .ThenByDescending(d => d.Value.Count(a => a.State == AnswerState.Comment))
                                      .ThenBy(d => d.Key.Name);
    List<Country> finalResult = answerDict.Keys.ToList();
