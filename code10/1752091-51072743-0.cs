public class CustomSessionHttpModule : IHttpModule
{
	public void Init(HttpApplication context)
	{
		IHttpModule httpModule = context.Modules.Get("Session");
		var sessionModule = httpModule as SessionStateModule;
		if (sessionModule != null)
		{
			sessionModule.Start += OnSessionStart;
		}
	}
	public void Dispose()
	{
	}
	private void OnSessionStart(object sender, EventArgs e)
	{
		//Check if user has active session( in your storage) if yes then invalidate it or block new request
	}
}
