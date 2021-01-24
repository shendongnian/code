        // Acquireing a Lease blob
        public async static Task<string> LockingEntity(dynamic entity, int leaseTimeInSec = 60, string leaseId = null)
        {
           while (true)
           {
              try
              {
                 string lid = await entity.AcquireLeaseAsync(TimeSpan.FromSeconds(leaseTimeInSec), leaseId);
                 if (string.IsNullOrEmpty(lid))
                    await Task.Delay(TimeSpan.FromMilliseconds(new Random(Guid.NewGuid().GetHashCode()).Next(250, 1000)));
                 else
                    return lid;
              }
              catch (StorageException ex)
              {
                 if (ex.RequestInformation.HttpStatusCode != 409)
                    throw;
              }
          }
       }
