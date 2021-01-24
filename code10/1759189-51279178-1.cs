    public class VersionChecker : AsyncTask
    {
    	protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
    	{
    		var val1 = Jsoup.Connect("https://play.google.com/store/apps/details?id=" + "com.app.in.app" + "&hl=en")
    			   .Timeout(30000).UserAgent("Mozilla/5.0 (Windows; U; WindowsNT 5.1; en-US; rv1.8.1.6) Gecko/20070725 Firefox/2.0.0.6").Referrer("http://www.google.com")
    			   .Get();
    		var val2 = val1.Select(".htlgb");
    		var val3 = val2.Get(7).ToString();
    		//here mobile app version is of 3 values like 2.1, 4.2 etc
    		var version = val3.Substring(val3.IndexOf(">") + 1, 3); //fetching only 3 values ex 1.1
    		CosntValues.PlayStoreValues = version;
    		return version;
    	}
    }
    public static class CosntValues
    {
    	public static string PlayStoreValues { get; set; }
    }
