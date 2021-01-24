    var data = _dbContext.Project
        .Select(p => new ProjectViewModel
        {
            Id = p.Id,
            Details = p.ProjectDetails
                .Select(pd => new KeyValuePair<string, List<string>>(pd.DetailDescription, pd.ProjectDetailsAnswers.Select(pda => pda.AnswerDescription).ToList())
                .ToList()
        })
       .ToList();
