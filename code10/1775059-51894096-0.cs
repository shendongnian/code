    public class QnADialog : IDialog, IDialogContinue
    {
    	public Task DialogBegin(DialogContext dc, IDictionary<string, object> dialogArgs = null)
    	{
    		string activity = "test";
    		dc.Context.SendActivity(activity);
    		//dc.Continue();
    		return Task.CompletedTask;
    	}
    	
    	public Task DialogContinue(DialogContext dc)
    	{
    		dc.Context.SendActivity("dc continue");
    		dc.Context.Responded = true;
    		return Task.CompletedTask;
    	}
    }
