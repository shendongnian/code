    Client GetCommitteeClient(int committeeID)
    {
        return (
            from AC in db.AdCommittees
            where AC.CommitteeID == committeeID 
            join A in db.Agencies.Where(agencyWhere) on AC.AgencyID equals A.AgencyID
            join RA in db.ClientAgencies on A.AgencyID equals RA.AgencyID
            join R in db.Clients.Where(clientWhere) on RA.SysID equals R.SysID
            select R
            ).SingleOrDefault();
    }
