    void Foo(JET_SESID sesid, JET_DBID dbid)
    {
        JET_TABLEID tableid;
    
        Api.JetBeginTransaction(sesid);
        Api.JetOpenTable(sesid, dbid, "table", null, 0, OpenTableGrbit.None, out tableid);
        // do something...
        if (somethingFailed)
        {
            Api.JetRollback(sesid, RollbackTransactionGrbit.None);
        }
        else
        {
            Api.JetCommitTransaction(sesid, CommitTransactionGrbit.None);
        }
    }
