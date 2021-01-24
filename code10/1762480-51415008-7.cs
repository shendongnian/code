    List<ProjectViewModel> result = _dbContext.Project
        .Where(x => /* conditions */)
        .Select(x => new ProjectViewModel
        {
            Id = x.Id,
            Answers = x.ProjectDetails.SelectMany(d => d.ProjectDetailAnswers).Select(a => new ProjectDetailAnswerViewModel
            {
                Id = a.Id,
                DetailDescription = a.ProjectDetail.Description,
                Description = a.Description,
            }
        }).ToList();
