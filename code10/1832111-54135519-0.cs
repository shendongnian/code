    [HttpPut("Amount/{id}")]
    public Worker Get(int id)
    {
        var worker = _context.Workers.Find(id);
        switch (worker)
        {
            case Driver d:
                var amountBonus = new AmountBonus(worker) { Id = id };
                amountBonus.ExecuteDecoration();
                _context.Entry(worker).State = EntityState.Modified;
                _context.SaveChanges();
                break;
        }
        return Ok(worker);
    }
