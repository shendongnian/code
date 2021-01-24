            var result = _dbContext.ProjectDetails //<==search from details
                .Select(x => new ProjectDetailViewModel
                {
                    projectTypeId = x.Project.ProjectTypeId,
                    projectType = x.Project.projectType,
                    DetailDescription = x.DetailDescription,
                    AnswerDescription = x.ProjectDetailsAnswers.Select(a => a.AnswerDescription)
                }).ToList();
