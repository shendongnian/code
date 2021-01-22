    public List<CustomerEntity> GetListWithCriteria(params ICriterion[] criterias){
            int positionTypeId = (int)this.PositionType;
            using (DbConnection cn = OpenConnection()) // creates DbConnection and opens it
            using (DbCommand cmd = cn.CreateCommand())
            {
                // ... setting command text ...
                foreach(ICriterion c in criterias){
                    DbParameter p = cmd.CreateParameter();
                    p.DbType = c.DbType;
                    p.Name = Encode(c.Name); // add '@' for MS SQL, ':' for Oracle
                    p.Value = c.Value;
                    cmd.AddParameter(p);
                }
                return this.GetCollectionFromReader(this.ExecuteReader(cmd));
            }        
    }
