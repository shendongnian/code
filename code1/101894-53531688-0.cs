	public class TimeTrialManager
	{
		private long expiryTime=0;
		private string softwareName = "";
		private string userPath="";
		private bool useSeconds = false;
		public TimeTrialManager(string softwareName) {
			this.softwareName = softwareName;
			// Create folder in Windows Application Data folder for persistence:
			userPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\" + softwareName + "_prefs\\";
			if (!Directory.Exists(userPath)) Directory.CreateDirectory(Path.GetDirectoryName(userPath));
			userPath += "timeinfo.txt";
		}
		// Use this method to check if the expiry has already been created. If
		// it has, you don't need to call the setExpiryDate() method ever again.
		public bool expiryHasBeenStored(){
			return File.Exists(userPath);
		}
		// Use this to set expiry as the number of days from the current time.
		// This should be called just once in the program's lifetime for that user.
		public void setExpiryDate(double days)	{
			DateTime time = DateTime.Now.AddDays(days);
			expiryTime = time.ToFileTimeUtc();
			storeExpiry(expiryTime.ToString() );
			useSeconds = false;
		}
		// Like above, but set the number of seconds. This should be just used for testing
		// as no sensible time trial would allow the user seconds to test the trial out:
		public void setExpiryTime(double seconds)	{
			DateTime time = DateTime.Now.AddSeconds(seconds);
			expiryTime = time.ToFileTimeUtc();
			storeExpiry(expiryTime.ToString());
			useSeconds = true;
		}
		// Check for this in a background timer or whenever else you wish to check if the time has run out
		public bool trialHasExpired()	{
			if(!File.Exists(userPath)) return false;
			if (expiryTime == 0)	expiryTime = Convert.ToInt64(File.ReadAllText(userPath));
			if (DateTime.Now.ToFileTimeUtc() >= expiryTime) return true; else return false;
		}
		// This method is optional and isn't required to use the core functionality of the class
		// Perhaps use it to tell the user how long he has left to trial the software
		public string expiryAsHumanReadableString(bool remaining=false)	{
			DateTime dt = new DateTime();
			dt = DateTime.FromFileTimeUtc(expiryTime);
			if (remaining == false) return dt.ToShortDateString() + " " + dt.ToLongTimeString();
			else {
				if (useSeconds) return dt.Subtract(DateTime.Now).TotalSeconds.ToString();
				else return (dt.Subtract(DateTime.Now).TotalDays ).ToString();
			}
		}
		// This method is private to the class, so no need to worry about it
		private void storeExpiry(string value)	{
			try	{ File.WriteAllText(userPath, value); }
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
	}
