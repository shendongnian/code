    <#@ template debug="true" hostSpecific="true" #>
    <#@ output extension=".generated.cs" #>
    <#@ Assembly Name="EnvDTE" #>
    <#@ Assembly Name="System.Core" #>
    <#@ Assembly Name="System.Data" #>
    <#@ assembly name="$(TargetPath)" #>
    <#@ import namespace="EnvDTE" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Data" #>
    <#@ import namespace="System.Data.SqlClient" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text.RegularExpressions" #>
    <#	
    	bool doDebug = false;	// include debug statements to appear in generated output    
    
        string schemaTableName = Path.GetFileNameWithoutExtension(Host.TemplateFile);
        string schema = schemaTableName.Split('.')[0];
        string tableName = schemaTableName.Split('.')[1];
    	
        string path = Path.GetDirectoryName(Host.TemplateFile);    
        string enumName = tableName;
    	string columnId = enumName + "Id";
    	string columnName = "Name";	
        string columnDescription = "Description";
    
    	string currentVersion = CompanyNamespace.Enumerations.Constants.Constants.DefaultDatabaseVersionSuffix;
    
    	// Determine Database Name using Schema Name
    	//
    	Dictionary<string, string> schemaToDatabaseNameMap = new Dictionary<string, string> {
    		{ "Cfg",		"SomeDbName" + currentVersion },
    		{ "Common",		"SomeOtherDbName" + currentVersion }
            // etc.		
    	};
    
    	string databaseName;
    	if (!schemaToDatabaseNameMap.TryGetValue(schema, out databaseName))
    	{
    		databaseName = "TheDefaultDatabase"; // default if not in map
        }
    
    	string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + databaseName + @";Data Source=Machine\Instance";
    
    	schema = "[" + schema + "]";
    	tableName = "[" + tableName + "]";
    
    	string whereConstraint = "1=1";  // adjust if needed for specific tables
    	
      // Get containing project
      IServiceProvider serviceProvider = (IServiceProvider)Host;
      DTE dte = (DTE)serviceProvider.GetService(typeof(DTE));
      Project project = dte.Solution.FindProjectItem(Host.TemplateFile).ContainingProject;
    #>
    using System;
    using System.CodeDom.Compiler;
    
    namespace <#= project.Properties.Item("DefaultNamespace").Value #><#= Path.GetDirectoryName(Host.TemplateFile).Remove(0, Path.GetDirectoryName(project.FileName).Length).Replace("\\", ".") #>
    {
        /// <summary>
        /// Auto-generated Enumeration from Source Table <#= databaseName + "." + schema + "." + tableName #>.  Refer to end of file for SQL.
        /// Please do not modify, your changes will be lost!
        /// </summary>
        [GeneratedCode("Auto Enum from DB Generator", "10")]
        public enum <#= enumName #>
        {		
    <#
    		SqlConnection conn = new SqlConnection(connectionString);
    		// Description is optional, uses name if null
    		string command = string.Format(
    			"select {0}, {1}, coalesce({2},{1}) as {2}" + "\n  from {3}.{4}.{5}\n where {6} order by {0}", 
    				columnId,			// 0
    				columnName,			// 1
    				columnDescription,	// 2
    				databaseName,	    // 3
    				schema,				// 4
    				tableName,			// 5
    				whereConstraint);	// 6
    		#><#= DebugCommand(databaseName, command, doDebug) #><#
    
    		SqlCommand comm = new SqlCommand(command, conn);
    
    		conn.Open();
    
    		SqlDataReader reader = comm.ExecuteReader();
    		bool loop = reader.Read();
    
    		while(loop)
    		{
    #>		/// <summary>
    		/// <#= reader[columnDescription] #>
    		/// </summary>
    		<#= Pascalize(reader[columnName]) #> = <#= reader[columnId] #><# loop = reader.Read(); #><#= loop ? ",\r\n" : string.Empty #>
    <#
    		}
    #>    }
    
    
        /// <summary>
        /// A helper class to return the Description for each enumeration value
        /// </summary>
        public partial class EnumDescription
        {
            public static string Description(<#= enumName #> enumeration)
            {
                string description = "Unknown";
    
                switch (enumeration)
                {<#
        conn.Close();
        conn.Open();
        reader = comm.ExecuteReader();
        loop = reader.Read();
    
        while(loop)
        {#>        	        
                        case <#= enumName #>.<#= Pascalize(reader[columnName]) #>:
                            description = "<#= reader[columnDescription].ToString().Replace("\"", "\\\"") #>";
                            break;
                        <# loop = reader.Read(); #>
    <#
          }
          conn.Close();
    #> 
                }
    
                return description;
            }
        }
        /*
    	    <#= command.Replace("\n", "\r\n        ") #>
        */
    }
    <#+		
        private string Pascalize(object value)
        {
            Regex rxStartsWithKeyWord = new Regex(@"^[0-9]|^abstract$|^as$|^base$|^bool$|^break$|^byte$|^case$|^catch$|^char$|^checked$|^class$|^const$|^continue$|^decimal$|^default$|^delegate$|^do$|^double$|^else$|^enum$|^event$|^explicit$|^extern$|^$false|^finally$|^fixed$|^float$|^for$|^foreach$|^goto$|^if$|^implicit$|^in$|^int$|^interface$|^internal$|^is$|^lock$|^long$|^namespace$|^new$|^null$|^object$|^operator$|^out$|^overrride$|^params$|^private$|^protected$|^public$|^readonly$|^ref$|^return$|^sbyte$|^sealed$|^short$|^sizeof$|^stackalloc$|^static$|^string$|^struct$|^switch$|^this$|^thorw$|^true$|^try$|^typeof$|^uint$|^ulong$|^unchecked$|^unsafe$|^ushort$|^using$|^virtual$|^volatile$|^void$|^while$", RegexOptions.Compiled);
     
            Regex rx = new Regex(@"(?:[^a-zA-Z0-9]*)(?<first>[a-zA-Z0-9])(?<reminder>[a-zA-Z0-9]*)(?:[^a-zA-Z0-9]*)");
            string rawName = rx.Replace(value.ToString(), m => m.Groups["first"].ToString().ToUpper() + m.Groups["reminder"].ToString());
    
            if (rxStartsWithKeyWord.Match(rawName).Success)
                rawName =  "_" + rawName;
    
            return rawName;    
    	}
    	
    	private string DebugCommand(string databaseName, string command, bool doDebug)
        {		
    		return doDebug
    			? "        // use " + databaseName + ";  " + command + ";\r\n\r\n"
    			: "";
    	}	
    #>
