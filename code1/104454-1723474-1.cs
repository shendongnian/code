    public void DoStuff(){
        TransactionRunner tr = new TransactionRunner(MyFunction);
        RunTransaction(tr, <a parameter>);
    }
    public void DoStuffInternal(DbConnection cn, DbTransaction trans, object state){
        //Do Stuff and Im sure that the transaction will commit or rollback
    }
