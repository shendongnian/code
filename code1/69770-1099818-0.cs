			<# // L2ST4 - LINQ to SQL templates for T4 v0.82 - http://www.codeplex.com/l2st4
			// Copyright (c) Microsoft Corporation.  All rights reserved.
			// This source code is made available under the terms of the Microsoft Public License (MS-PL)
			#><#@ template language="C#v3.5" hostspecific="True"
			#><#@ include file="L2ST4.ttinclude"
			#><#@ output extension=".generated.cs"
			#><# // Set options here
			var options = new {
				DbmlFileName = Host.TemplateFile.Replace(".tt",".dbml"), // Which DBML file to operate on (same filename as template)
				SerializeDataContractSP1 = false, // Emit SP1 DataContract serializer attributes
				FilePerEntity = true, // Put each class into a separate file
				StoredProcedureConcurrency = false, // Table updates via an SP require @@rowcount to be returned to enable concurrency
				EntityFilePath = Path.GetDirectoryName(Host.TemplateFile) // Where to put the files	
			};
			var code = new CSharpCodeLanguage();
			var data = new Data(options.DbmlFileName);
			var manager = new Manager(Host, GenerationEnvironment, true) { OutputPath = options.EntityFilePath };
			data.ContextNamespace = (new string[] { manager.GetCustomToolNamespace(data.DbmlFileName), data.SpecifiedContextNamespace, manager.DefaultProjectNamespace }).FirstOrDefault(s => !String.IsNullOrEmpty(s));
			data.EntityNamespace = (new string[] { manager.GetCustomToolNamespace(data.DbmlFileName), data.SpecifiedEntityNamespace, manager.DefaultProjectNamespace }).FirstOrDefault(s => !String.IsNullOrEmpty(s));
			manager.StartHeader();
			manager.EndHeader();
			var tableOperations = new List<TableOperation>();
				foreach(var table in data.Tables)
					tableOperations.AddRange(table.Operations);
				foreach(Table table in data.Tables)
					foreach(OperationType operationType in Enum.GetValues(typeof(OperationType)))
						if (!tableOperations.Any(o => (o.Table == table) && (o.Type == operationType))) {}
			if (!String.IsNullOrEmpty(data.ContextNamespace)) {}
			foreach(Table table in data.Tables) {
				foreach(TableClass class1 in table.Classes) {
					manager.StartBlock(Path.ChangeExtension(class1.Name + "Info" ,".cs"));
					if (!String.IsNullOrEmpty(data.EntityNamespace)) {#>
			using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			namespace <#=data.EntityNamespace#>
			{	
			<#		}
				
			#>	<#=code.Format(class1.TypeAttributes)#> class <#=class1.Name#>Info
				{
			<#		int dataMemberIndex = 1;
					if (class1.Columns.Count > 0) {
			#><#			foreach(Column column in class1.Columns) {#>
					private <#=code.Format(column.StorageType)#> <#= "_" + char.ToLower(column.Member[0]) +  column.Member.Substring(1) #><# if (column.IsReadOnly) {#> = default(<#=code.Format(column.StorageType)#>)<#}#>;
					
					<#=code.Format(column.MemberAttributes)#><#=code.Format(column.Type)#> <#=column.Member#>
					{
						get { return <#= "_" + char.ToLower(column.Member[0]) +  column.Member.Substring(1) #>; }
						set {<#= "_" + char.ToLower(column.Member[0]) +  column.Member.Substring(1) #> = value;}
					}
					
			<#			}
					}
			#>
				}
			}
			<#		
					manager.EndBlock();
				}
			}
			manager.StartFooter();
			manager.EndFooter(); 
			manager.Process(options.FilePerEntity);#>
