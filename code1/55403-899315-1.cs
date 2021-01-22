        private void WriteUsers()
		{	
			string userCountString = null;
			ASCIIEncoding enc = new ASCIIEncoding();
			byte[] userCountBytes = null;
			int userCounter = 0;
			
			using(StreamWriter sw = File.CreateText("myfile.txt"))
			{
				// Write a blank line and return
				// Note this line will later contain our user count.
				sw.WriteLine();
				
				// Write out the records and keep track of the count 
				for(int i = 1; i < 100; i++)
				{
					sw.WriteLine("User" + i);
					userCounter++;
				}
				
				// Get the base stream and set the position to 0
				sw.BaseStream.Position = 0;
				
				userCountString = "User Count: " + userCounter;
				
				userCountBytes = enc.GetBytes(userCountString);
			
				sw.BaseStream.Write(userCountBytes, 0, userCountBytes.Length);
			}
		}
