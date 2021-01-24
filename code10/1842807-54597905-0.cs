    namespace Website.Pipelines
    {
	  public class UnpublishArchivedItem : DeleteItems
      {
		public void Process(ClientPipelineArgs args)
		{
		    Assert.ArgumentNotNull(args, "args");
		    Database database = Factory.GetDatabase(args.Parameters["database"]);
		    Assert.IsNotNull(database, typeof(Database), "Name: {0}", args.Parameters["database"]);
            ListString listStrings = new ListString(args.Parameters["items"], '|');
            
            Database target = Factory.GetDatabase("web"); 
            foreach (string listString in listStrings)
		    {
		        Item item = database.GetItem(listString, Language.Parse(args.Parameters["language"]));
		        if (item == null)
		        {
		            continue;
		        }
                Log.Audit(this, "Unpublish item: {0}", new string[] { AuditFormatter.FormatItem(item) });
                item.Editing.BeginEdit();
		        item.Publishing.NeverPublish = true;
		        item.Editing.EndEdit();
		        PublishManager.PublishItem(item.Parent, new []{ target }, item.Languages, true, false);
		    }
        }
	  }
    }
