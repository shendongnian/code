    public class ExamineEvents : Umbraco.Core.ApplicationEventHandler
    {
    	protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    	{
    		var indexer = (UmbracoContentIndexer)ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"];
    		indexer.DocumentWriting += Indexer_DocumentWriting;
    		Umbraco.Core.Services.ContentService.Published += ContentService_Published;
    	}
    
    	private void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
    	{
    		ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"].RebuildIndex();
    	}
    
    	private void Indexer_DocumentWriting(object sender, DocumentWritingEventArgs e)
    	{
    		//if it is a 'news article' doc type then > BOOST it DOWN - the older the article, the lower the boost value 
    		if (e.Fields.ContainsKey("nodeTypeAlias") && e.Fields["nodeTypeAlias"] == "newsArticle")
    		{
    			float boostValue = 1f;
    			const string umbDateField = "updateDate";
    			if (e.Fields.ContainsKey(umbDateField))
    			{
    				DateTime updateDate = DateTime.Parse(e.Fields[umbDateField]);
    				var daysInBetween = Math.Ceiling((DateTime.Now - updateDate).TotalDays + 1); // +1 to avoid 0 days
    				boostValue = (float) (1 / daysInBetween);
    			}
    			e.Document.SetBoost(boostValue);
    		}
    	}
    }
