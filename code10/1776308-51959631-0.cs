    void Main()
    {
    	string DatabaseName = "Blah";
    	string ServerIP = @"(localdb)\MSSQLLocalDB";
    	List<string> ExcludeList = new List<string>()
    	{
    		"sp_upgraddiagrams",
    		"sp_helpdiagrams",
    		"sp_helpdiagramdefinition",
    		"sp_creatediagram",
    		"sp_renamediagram",
    		"sp_alterdiagram",
    		"sp_dropdiagram"
    	};
    
    	List<string> StringDataTypes = new List<string>()
    	{
    		"nvarchar",
    		"varchar",
    		"nchar",
    		"char",
    	};
    
    	Server s = new Server(ServerIP);
    	s.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");
    	Database db = s.Databases[DatabaseName];
    
    	Dictionary<string, SPAudit> AuditList = new Dictionary<string, SPAudit>();
    
    	var sps = db.StoredProcedures.Cast<StoredProcedure>()
    	.Where(x => x.ImplementationType == ImplementationType.TransactSql && x.Schema == "dbo" && !x.IsSystemObject)
    	.Select(x => new
    	{
    		x.Name,
    		Body = x.TextBody,
    		Parameters = x.Parameters.Cast<StoredProcedureParameter>().Select(t =>
    		new SPParam()
    		{
    			Name = t.Name,
    			DefaultValue = t.DefaultValue,
    			DataType = $"{t.DataType.Name}{(StringDataTypes.Contains(t.DataType.Name) ? $"({(t.DataType.MaximumLength > 0 ? Convert.ToString(t.DataType.MaximumLength) : "MAX")})" : "")}"
    		})
    	}).ToList();
    
    	foreach (var item in sps)
    	{
    		try
    		{
    			TSqlParser parser = new TSql140Parser(true, SqlEngineType.Standalone);
    			IList<ParseError> parseErrors;
    			TSqlFragment sqlFragment = parser.Parse(new StringReader(item.Body), out parseErrors);
    			sqlFragment.Accept(new OwnVisitor(ref AuditList, item.Name, item.Parameters));
    		}
    		catch (Exception ex)
    		{
    			//Handle exception
    		}
    	}
    }
    
    public class OwnVisitor : TSqlFragmentVisitor
    {
    	private string spname;
    	private IEnumerable<SPParam> parameters;
    	private Dictionary<string, SPAudit> list;
    
    	public OwnVisitor(ref Dictionary<string, SPAudit> _list, string _name, IEnumerable<SPParam> _parameters)
    	{
    		list = _list;
    		spname = _name;
    		parameters = _parameters;
    	}
    
    	public override void ExplicitVisit(InsertStatement node)
    	{
    		NamedTableReference namedTableReference = node?.InsertSpecification?.Target as NamedTableReference;
    		if (namedTableReference != null)
    		{
    			string table = namedTableReference?.SchemaObject.BaseIdentifier?.Value;
    			if (!string.IsNullOrWhiteSpace(table) && !table.StartsWith("#"))
    			{
    				if (!list.ContainsKey(spname))
    				{
    					SPAudit ll = new SPAudit();
    					ll.InsertTable.Add(table);
    					ll.Parameters.AddRange(parameters);
    					list.Add(spname, ll);
    				}
    				else
    				{
    					SPAudit ll = list[spname];
    					ll.InsertTable.Add(table);
    				}
    			}
    		}
    		base.ExplicitVisit(node);
    	}
    
    	public override void ExplicitVisit(UpdateStatement node)
    	{
    		NamedTableReference namedTableReference;
    		if (node?.UpdateSpecification?.FromClause != null)
    		{
    			namedTableReference = node?.UpdateSpecification?.FromClause?.TableReferences[0] as NamedTableReference;
    		}
    		else
    		{
    			namedTableReference = node?.UpdateSpecification?.Target as NamedTableReference;
    		}
    		string table = namedTableReference?.SchemaObject.BaseIdentifier?.Value;
    		if (!string.IsNullOrWhiteSpace(table) && !table.StartsWith("#"))
    		{
    			if (!list.ContainsKey(spname))
    			{
    				SPAudit ll = new SPAudit();
    				ll.UpdateTable.Add(table);
    				ll.Parameters.AddRange(parameters);
    				list.Add(spname, ll);
    			}
    			else
    			{
    				SPAudit ll = list[spname];
    				ll.UpdateTable.Add(table);
    			}
    		}
    		base.ExplicitVisit(node);
    	}
    
    	public override void ExplicitVisit(DeleteStatement node)
    	{
    		NamedTableReference namedTableReference;
    		if (node?.DeleteSpecification?.FromClause != null)
    		{
    			namedTableReference = node?.DeleteSpecification?.FromClause?.TableReferences[0] as NamedTableReference;
    		}
    		else
    		{
    			namedTableReference = node?.DeleteSpecification?.Target as NamedTableReference;
    		}
    		if (namedTableReference != null)
    		{
    			string table = namedTableReference?.SchemaObject.BaseIdentifier?.Value;
    			if (!string.IsNullOrWhiteSpace(table) && !table.StartsWith("#"))
    			{
    				if (!list.ContainsKey(spname))
    				{
    					SPAudit ll = new SPAudit();
    					ll.DeleteTable.Add(table);
    					ll.Parameters.AddRange(parameters);
    					list.Add(spname, ll);
    				}
    				else
    				{
    					SPAudit ll = list[spname];
    					ll.DeleteTable.Add(table);
    				}
    			}
    		}
    		base.ExplicitVisit(node);
    	}
    }
    
    public class SPAudit
    {
    	public HashSet<string> InsertTable { get; set; }
    	public HashSet<string> UpdateTable { get; set; }
    	public HashSet<string> DeleteTable { get; set; }
    	public List<SPParam> Parameters { get; set; }
    
    	public SPAudit()
    	{
    		InsertTable = new HashSet<string>();
    		UpdateTable = new HashSet<string>();
    		DeleteTable = new HashSet<string>();
    		Parameters = new List<SPParam>();
    	}
    }
    
    public class SPParam
    {
    	public string Name { get; set; }
    	public string DefaultValue { get; set; }
    	public string DataType { get; set; }
    }
