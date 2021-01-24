    int[] groupIDs = await _db.DistributionGroupInSms.Where(dgis => dgis.SmsId == message.Id).Select(g => g.Id).ToArrayAsync();
    var recipients = await (from dgm in _db.DistributionGroupMembers
                            join c in _db.Contacts on dgm.ContactId equals c.Id
                            join dg in _db.DistributionGroups on dgm.DistributionGroupId equals dg.Id
                            join gIds in groupIDs on gIds equals dg.Id
                            select new
                            {
                                ID = c.Id,
                                FN = c.FirstName,
                                LN = c.LastName,
                                PN = c.PhoneNumber,
                                SR = "Waiting to be sent"
                            }).Distinct().ToListAsync();
