    public void DeleteTask(TWFITSKs task)
    {
        if (task == null) return;
        _context.TWFITSKs.Remove(task);
        _context.SaveChanges();
    }
