    public void MyAddUpdateMethod()
    {
        using (TransactionScope Scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        {
            using(SQLServer Sql = new SQLServer(this.m_connstring))
            {
                //do my first add update statement            
            }
            
            //removed the method call from the first sql server using statement
            bool DoesRecordExist = this.SelectStatementCall(id)
        }
    }
    
    public bool SelectStatementCall(System.Guid id)
    {
        using(SQLServer Sql = new SQLServer(this.m_connstring))
        {
            //create parameters
        }
    }
