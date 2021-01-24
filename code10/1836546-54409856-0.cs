    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations.Design;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Utilities;
    using System.Linq;
    
    class CustomMigrationCodeGenerator : CSharpMigrationCodeGenerator
    {
    	public override ScaffoldedMigration Generate(string migrationId, IEnumerable<MigrationOperation> operations, string sourceModel, string targetModel, string @namespace, string className)
    	{
    		foreach (var fkOperation in operations.OfType<ForeignKeyOperation>()
    			.Where(op => op.HasDefaultName))
    		{
    			fkOperation.Name = fkOperation.Name.Replace("dbo.", "");
    			// or generate FK name using DependentTable, PrincipalTable and DependentColumns properties,
    			// removing schema from table names if needed
    		}
    		foreach (var pkOperation in operations.OfType<PrimaryKeyOperation>()
    			.Concat(operations.OfType<CreateTableOperation>().Select(op => op.PrimaryKey))
    			.Where(op => op.HasDefaultName))
    		{
    			pkOperation.Name = pkOperation.Name.Replace("dbo.", "");
    			// or generate PK name using Table and Columns properties,
    			// removing schema from table name if needed
    		}
    		return base.Generate(migrationId, operations, sourceModel, targetModel, @namespace, className);
    	}
    
    	protected override void GenerateInline(AddForeignKeyOperation addForeignKeyOperation, IndentedTextWriter writer)
    	{
    		writer.WriteLine();
    		writer.Write(".ForeignKey(" + Quote(addForeignKeyOperation.PrincipalTable) + ", ");
    		Generate(addForeignKeyOperation.DependentColumns, writer);
    		if (addForeignKeyOperation.CascadeDelete)
    			writer.Write(", cascadeDelete: true");
    		// { missing in base implementation
    		if (!addForeignKeyOperation.HasDefaultName)
    		{
    			writer.Write(", name: ");
    			writer.Write(Quote(addForeignKeyOperation.Name));
    		}
    		// }
    		writer.Write(")");
    	}
    }
