    foreach (HttpPostedFileBase image in images)
    {
        var imageSubmit = new PlanItemImage
        {
            PlanId = planIdGUID,
            PlanImageId = Guid.NewGuid(),
            Image = image.ConvertToByte(),
            ImageTitle = image.FileName
        };
        context.Image.Add(imageSubmit);    
    }
    context.SaveChanges();
