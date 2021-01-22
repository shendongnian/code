    using System.Linq.Dynamic;
    ...
    
    {
        var questions = context.Questions;
        if (!string.IsNullOrEmpty(sidx))
            questions = questions.OrderBy(sidx + " " + sord).Skip(pageIndex * pageSize);
    
        return questions.Take(pageSize);
    }
