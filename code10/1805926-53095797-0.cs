    public async Task<bool> DeleteEmployeeSchedule(string employeeId, string loantypecode)
    {
         var scheduleList = (await _repository.FindBy(e => e.EmployeeId == employeeId && e.LoanTypeCode == loantypecode).ToList();
         
         //TODO:  the line below will only clear the list, it wont persist any changes.
         scheduleList.Clear()
         return Task.FromResult(true);
    }  
