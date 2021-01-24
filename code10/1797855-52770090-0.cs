    public ILookup<string, EEntry> GetEEntries(int batchId, List<string> employeeIds)
    {
      if(employeeIds == null) throw new ArgumentNullException("employeeIds");
      employeeIds = employeeIds.ConvertAll(x => x.ToUpper());
      using (WithNoLock())
      {
        var result = from e in _entities.EEntries
                     where e.CPayBatchProcessId == batchId
                           && (!e.Blocked.HasValue || e.Blocked.Value != true)
                           && employeeIds.Contains(e.Id.ToUpper())
                     select e;
    
        return result.ToLookup(e => e.Id, StringComparer.OrdinalIgnoreCase);
      }
    }
