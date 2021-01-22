private static void IndexingThread(object contextObj)
{
     Range<int> range = (Range<int>)contextObj;
     Document newDoc = new Document();
     newDoc.Add(new Field("title", "", Field.Store.NO, Field.Index.ANALYZED));
     newDoc.Add(new Field("body", "", Field.Store.NO, Field.Index.ANALYZED));
     newDoc.Add(new Field("newsdate", "", Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
     newDoc.Add(new Field("id", "", Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
     for (int counter = range.Start; counter <= range.End; counter++)
     {
         newDoc.GetField("title").SetValue(Entities[counter].Title);
         newDoc.GetField("body").SetValue(Entities[counter].Body);
         newDoc.GetField("newsdate").SetValue(Entities[counter].NewsDate);
         newDoc.GetField("id").SetValue(Entities[counter].ID.ToString());
         writer.AddDocument(newDoc);
     }
}
