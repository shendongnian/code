    var result = _dbContext.ProjectDetails.ProjectDetailsAnswers //<==search from details
            .Select(x => new ProjectDetailViewModel
            {
                projectTypeId = x.ProjectDetail.Project.ProjectTypeId,
                projectType = x.ProjectDetail.Project.projectType,
                DetailDescription = x.ProjectDetail.DetailDescription,
                AnswerDescription = x.Select(a => a.AnswerDescription)
            }).ToList();
