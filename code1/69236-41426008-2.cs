	Console.WriteLine("Downloading file....");
	var watch = new Stopwatch();
	byte[] data;
	using (var client = new System.Net.WebClient())
	{
		watch.Start();
		data = client.DownloadData("http://dl.google.com/googletalk/googletalk-setup.exe?t=" + DateTime.Now.Ticks);
		watch.Stop();
	}
			
	var speed = data.LongLength / watch.Elapsed.TotalSeconds; // instead of [Seconds] property
	Console.WriteLine("Download duration: {0}", watch.Elapsed);
	Console.WriteLine("File size: {0}", data.Length.ToString("N0"));
	Console.WriteLine("Speed: {0} bps ", speed.ToString("N0"));
	Console.WriteLine("Press any key to continue...");
	Console.ReadLine();
