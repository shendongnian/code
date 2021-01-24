    public List<ablamm> Getablamm1([FromRoute]string schaf)
        {
            var query = _context.ablamm.Where(s => s.schaf_nr == schaf);
            return query.ToList();
        }
