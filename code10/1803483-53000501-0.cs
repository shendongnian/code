    var comments = DatabaseService.GetAll(filter)
        .OrderByDescending(x => x.Id)
        .ToPaginated(page)
        .ToList()//Applied ToList here
        .Select(x => new PostCommentViewModel
        {
            Id = x.Id,
            Comment = x.Comment,
            Created = x.Created,
            Name = x.Name,
            ParentId = x.ParentId,
            PostId = x.PostId,
            Status = x.Status.TryConvertToEnum(out PostCommentStatusType returnedValue) ?
                returnedValue : PostCommentStatusType.None 
        }).ToList(); 
