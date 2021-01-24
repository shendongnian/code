    List<ProjectViewModel> result = _dbContext.Projects
        .Where(x => /* conditions */)
        .Select(x => new ProjectViewModel
        {
            Id = x.Id,
            Details = x.ProjectDetails.Select(d => new ProjectDetailViewModel
            {
                Id = d.Id,
                Description = d.Description,
                Answers = d.ProjectDetailAnswers.Select(a => new AnswerViewModel
                { 
                    Id = a.Id,
                    Description = a.Description
                }
            }
        }).ToList();
