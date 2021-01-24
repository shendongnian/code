    public Worker GetByIdWithXEntity(id)
    {
        this.Queryable()
            .Include(worker => worker.XEntity)
            .Where(worker => worker.ID == id)
            .SingleOrDefault();
    }
