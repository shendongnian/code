    using System.Management.Automation;
    static class PoshExec
    {
    	static void Exec(string scriptFilePath)
    	{
    		(new RunspaceInvoke()).Invoke("& " + scriptFilePath);
    	}
    }
