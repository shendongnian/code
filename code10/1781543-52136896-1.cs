    class PublishAnnouncement {
	private static readonly object syncLock = new object();
 
	public static void PostAnnoucment(string message, string TwAccountKey, string FbAccountKey, string[] JourneyRefID, double latness, MainWindow mainWindow) {
		lock(syncLock) {
			//First it is published to facebook
			BackgroundWorker FacebookWorker = new BackgroundWorker();
			FacebookWorker.DoWork += (obj, e) => FacebookDoWork(message, FbAccountKey);
			FacebookWorker.RunWorkerAsync();
			//Then it is published to twitter - This is where it appears to fail
			BackgroundWorker TwitterWorker = new BackgroundWorker();
			TwitterWorker.DoWork += (obj, e) => TwitterDoWork(message, TwAccountKey, JourneyRefID, latness, mainWindow, 0);
			TwitterWorker.RunWorkerAsync();
	  
			//etc
		}
	}
