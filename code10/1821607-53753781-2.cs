	public static ObjectId CreateObjectActionWithinTransaction(MyCreateDelegate createDel)
	{
		ObjectId ret;
		var document = Application.DocumentManager.MdiActiveDocument;
		var database = document.Database;
		using (var transaction = document.TransactionManager.StartTransaction())
		{
			BlockTable blocktable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;
			BlockTableRecord blockTableRecord = transaction.GetObject(blocktable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
			//here createMtext will get called in this case, and return ObjectID
			ret = createDel(transaction, database, blocktable, blockTableRecord);
			transaction.Commit();
		}
		return ret;
	}
