    using System;
    using System.Collections.Generic;
    using System.Net;
    
    class Program
    {
        static void onEx(Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    
    	static IEnumerable<Uri> Downloader(Func<DownloadDataCompletedEventArgs> getLastResult) {
    		Uri url1 = new Uri(Console.ReadLine());
    		Uri url2 = new Uri(Console.ReadLine());
    		string someData = Console.ReadLine();
    		yield return url1;
    
    		DownloadDataCompletedEventArgs res1 = getLastResult();
    		yield return new Uri(url2.ToString() + "?data=" + res1.Result);
    
    		DownloadDataCompletedEventArgs res2 = getLastResult();
    		Console.WriteLine(someData + res2.Result);
    	}
    
    	static void StartNextRequest(WebClient webThingy, IEnumerator<Uri> enumerator) {
    		if (enumerator.MoveNext()) {
    			Uri uri = enumerator.Current;
    			
    			try {
    				Console.WriteLine("Requesting {0}", uri);
    				webThingy.DownloadDataAsync(uri);
    			} catch (Exception ex) { onEx(ex); }
    		}
    		else
    			Console.WriteLine("Finished");
    	}
    
        static void Main() {
    		DownloadDataCompletedEventArgs lastResult = null;
            Func<DownloadDataCompletedEventArgs> getLastResult = delegate { return lastResult; };
    		IEnumerable<Uri> enumerable = Downloader(getLastResult);
    		using (IEnumerator<Uri> enumerator = enumerable.GetEnumerator())
    		{
    			WebClient webThingy = new WebClient();
    			webThingy.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e) {
    				if (e.Error == null) {
    					lastResult = e;
    					StartNextRequest(webThingy, enumerator);
    				}
    				else
    					onEx(e.Error);
    			};
    
    			StartNextRequest(webThingy, enumerator);
    		}
    
            Console.WriteLine("Keeping process alive");
            Console.ReadLine();
        }
    }
