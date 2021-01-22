    DataClient.Add
              .Table("TableName")
              .WithColumns(
    		     Column.AutoIncrement("ID").NotNull().AsPrimaryKey(),
    		     Column.String("NAME"),
    		     Column.Date("DATESTART"),
    		     Column.Int32("SOMENUMBER"),
    	      );
