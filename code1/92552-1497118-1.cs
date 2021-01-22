    var trails = Audits.Select(a =>
        new Trail
        {
            Comment = a.Comment,
            CreatedBy = a.CreatedBy,
            CreatedDate = a.CreatedDate,
            ImageID = a.ImageID,
            LowResUrl = Images.Single(i => i.ImageID == a.ImageID).LowResUrl
        });
