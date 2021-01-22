		public static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
		{
			using(Stream stream = File.Create(file))
			{
				try {
					Console.Out.Write("Writing cookies to disk... ");
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, cookieJar);
					Console.Out.WriteLine("Done.");
				} catch(Exception e) { 
					Console.Out.WriteLine("Problem writing cookies to disk: " + e.GetType()); 
				}
			}
		}	
		
		public static CookieContainer ReadCookiesFromDisk(string file)
		{
			
			try {
				using(Stream stream = File.Open(file, FileMode.Open))
				{
					Console.Out.Write("Reading cookies from disk... ");
					BinaryFormatter formatter = new BinaryFormatter();
					Console.Out.WriteLine("Done.");
					return (CookieContainer)formatter.Deserialize(stream);
				}
			} catch(Exception e) { 
				Console.Out.WriteLine("Problem reading cookies from disk: " + e.GetType()); 
				return new CookieContainer(); 
			}
		}
