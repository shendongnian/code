    $Assem = ("Microsoft.SqlServer.Smo","Microsoft.SqlServer.ConnectionInfo")
    $Source = @"
    public class MyMSSql
    {
           public static string getEdition(string sqlName)
           {
               string sqlEdition;
               Microsoft.SqlServer.Management.Smo.Server sname = new Microsoft.SqlServer.Management.Smo.Server(sqlName);
               sqlEdition = sname.Information.Edition;
               return sqlEdition;
           }
    	   public string getSqlEdition(string sqlName)
           {
               string sqlEdition;
               Microsoft.SqlServer.Management.Smo.Server sname = new Microsoft.SqlServer.Management.Smo.Server(sqlName);
               sqlEdition = sname.Information.Edition;
               return sqlEdition;
           }
    
    }
    "@;
    Add-Type -ReferencedAssemblies $Assem -TypeDefinition $Source
    [MyMSSql]::getEdition("MAX-PCWIN1")
    #Developer Edition (64-bit)
    
    $MySQLobj = New-Object MyMSSql
    $MySQLobj.getSqlEdition("MAX-PCWIN1")
