    class Blah {
    	public void DoStuff() {
    	}
    }
			List<Blah> blahs = new List<Blah>();
			DateTime start = DateTime.Now;
			
			for(int i = 0; i < 30000000; i++) {
				blahs.Add(new Blah());
			}
			TimeSpan elapsed = (DateTime.Now - start);
			Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Allocation - {0:00}:{1:00}:{2:00}.{3:000}",
			 elapsed.Hours,
			 elapsed.Minutes,
			 elapsed.Seconds,
			 elapsed.Milliseconds));
			start = DateTime.Now;
			foreach(var bl in blahs) {
				bl.DoStuff();
			}
			elapsed = (DateTime.Now - start);
			Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "foreach - {0:00}:{1:00}:{2:00}.{3:000}",
			 elapsed.Hours,
			 elapsed.Minutes,
			 elapsed.Seconds,
			 elapsed.Milliseconds));
			start = DateTime.Now;
			blahs.ForEach(bl=>bl.DoStuff());
			elapsed = (DateTime.Now - start);
			Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "lambda - {0:00}:{1:00}:{2:00}.{3:000}",
			 elapsed.Hours,
			 elapsed.Minutes,
			 elapsed.Seconds,
			 elapsed.Milliseconds));
