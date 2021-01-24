    context.Entry(devblogInDb).State = EntityState.Detached;
    devblogInDb.Fixs = devblog.Fixs;
    devblogInDb.News = devblog.News;
    devblogInDb.Removes = devblog.Removes;
    devblogInDb.Updates = devblog.Updates;
    devblogInDb.PatchName = devblog.PatchName;
    context.Entry(devblogInDb).State = EntityState.Modified;
