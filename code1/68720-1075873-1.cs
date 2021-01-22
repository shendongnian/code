    class Tuple
    {
        Election election;
        Election_status election_status;
    
        public Tuple(Election election, Election_status election_status)
        {
            this.election = election;
            this.election_status = election_status;
        }
    }
    
    public IEnumerable<Tuple> getElections()
    {
        IEnumerable<Tuple> result = null;
    
        using (ormDataContext context = new ormDataContext(connStr))
        {
            result = from t1 in context.elections
                     join t2 in context.election_status
                     on t1.statusID equals t2.statusID
                     select new Tuple(t1, t2);
        }
    }
