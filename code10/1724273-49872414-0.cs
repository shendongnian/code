    		DateTime dt = DateTime.Now;
    		int[] timeOnly = Array.ConvertAll(dt.ToString("HH:mm:ss").Split(':'), int.Parse);
    		TimeSpan ts = new TimeSpan(timeOnly[0],timeOnly[1],timeOnly[2]);
    		  if (ts >= new TimeSpan(11, 0, 0) && ts <= new TimeSpan(20, 0, 0)) {
    			  Console.WriteLine("InBetween");
      }
    		else
    			Console.WriteLine(dt.ToString("HH:mm:ss"));
