    public List<StatusDetailsViewModel> CheckMeetingStatus(long actionId)
    {
         List<StatusDetailsViewModel> statusDetails;
    
         var statuses = _igniteDb.myTable.Where(a => a.actionId == actionId)
                    .GroupBy(a => new { a.Status, a.ElectionGroup }).GroupBy(c => new { c.Key.Status})
                    .Select(b => new StatusDetailsViewModel () { Status = b.Key.Status, CountNo = b.Count()}).ToList();
    
         //How to Map statuses to statusDetails??
    
         return statusDetails;
    }
