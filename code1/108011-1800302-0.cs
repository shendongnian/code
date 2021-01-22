PublishingPageCollection pages = PublishingWeb.GetPublishingWeb(web).GetPublishingPages();
foreach (PublishingPage page in pages)
{
    if(!page.ListItem.File.Level == SPFileLevel.Published)
       return;<br />
    // logic
}
