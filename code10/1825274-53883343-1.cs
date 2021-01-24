    public List<ablamm> Getablamm1([FromRoute]string schaf)
        {
            List<ablamm> query = (_context.ablamm.Where(s => s.schaf_nr == schaf)).ToList();
            return query;
        }
