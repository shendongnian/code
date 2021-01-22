    // this is System.Threading.Timer
    _timer = new Timer(x =>
                      {
                          var listOfExpiringContracts = GetContractsThatAreAboutToExpire();
                          if (listOfExpiringContracts.Count > 0)
                          {
                              SendEmailToOtherDepartmentRegardingContractsThatAreAboutToExpire(listOfExpiringContracts);
                          }
                      }, null, GetNextTimeToCheckForExpiringContracts().Subtract(DateTime.Now), TimeSpan.FromDays(1));
