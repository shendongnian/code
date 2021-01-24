    public class ImageResizer : ApplicationEventHandler
    {
            protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
            {
                MediaService.Saving += MediaServiceSaving;
            }
            void MediaServiceSaving(IMediaService sender, SaveEventArgs<IMedia> e)
            {
                foreach (var mediaItem in e.SavedEntities)
                {
                    //if it's an image, the content type will tell you.
                    if(mediaItem.ContentType.Alias == "Image")
                    {
                        var width = Convert.ToDouble(mediaItem.Properties["umbracoWidth"].Value);
                        var height = Convert.ToDouble(mediaItem.Properties["umbracoHeight"].Value);
                        
                        if (height / width != 1)
                        {                        
                      //Sending a message will cancel the process, so you don't
                      //need an else (unless you want to do something else with the image of course.
                            e.Messages.Add(new EventMessage("Wrong Ratio", "Ratio is not 1:1. Please make sure the width and height of your image is the same.", EventMessageType.Error));                        
                        }                    
                    }
                }
            }
    }
