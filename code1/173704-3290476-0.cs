		static void example(string filename)
		{
			StreamReader sr;
			BinaryWriter bw;
			try
			{
				sr = new StreamReader(filename);
				bw = new BinaryWriter(File.Open("out.bin", FileMode.Create));
				bw.Write(sr.ReadToEnd());
				bw.Flush();
				bw.Close();
				sr.Close();
			}
			catch(Exception ex)
			{
				// Handle the exception
			}
		}
