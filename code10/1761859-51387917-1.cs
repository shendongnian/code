            var result = _dbContext.Projects.SelectMany(x=>x.ProjectDetails) //<==use SelectMany
                .Select(x => new ProjectDetailViewModel
                {
                    projectTypeId = x.Project.ProjectTypeId,
                    projectType = x.Project.projectType,
                    DetailDescription = x.DetailDescription,
                    AnswerDescription = x.ProjectDetailsAnswers.Select(a => a.AnswerDescription)
                }).ToList();
