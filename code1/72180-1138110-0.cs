    abstract class Base { protected abstract void Clone(); }
    
    abstract class ConcreteForDatabases : Base 
    { 
    	protected abstract string CopyInsertStatemement {get;}
    
    	protected override void Clone()
    	{
    		// setup db connection & command objects
    		string sql = CopyInsertStatemement;
    		// process the statement
    	}
    }
    
    class CustomBusinessThingy : ConcreteForDatabases 
    {
    	protected override string CopyInsertStatemement {get{return "insert myTable(...) select ... from myTable where ...";}}
    }
