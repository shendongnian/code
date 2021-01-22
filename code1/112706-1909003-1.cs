    const string Root = @"C:\_Sha1Buckets";
    using (TextWriter writer = File.CreateText(@"C:\_Sha1Buckets.txt"))
    {
    	// simulate a very even distribution like SHA-1 would produce
    	RandomNumberGenerator rand = RandomNumberGenerator.Create();
    	byte[] sha1 = new byte[20];
    	Stopwatch watch = Stopwatch.StartNew();
    
    	for (int i=0; i<1000000; i++)
    	{
    		// populate bytes with a fake SHA-1
    		rand.GetBytes(sha1);
    
    		// format bytes into hex string
    		string hash = FormatBytes(sha1);
    
    		// C:\_Sha1Buckets
    		StringBuilder builder = new StringBuilder(Root, 60);
    
    		// \012\345\6789abcdef0123456789abcdef01234567\
    		builder.Append(Path.DirectorySeparatorChar);
    		builder.Append(hash, 0, 3);
    		builder.Append(Path.DirectorySeparatorChar);
    		builder.Append(hash, 3, 3);
    		builder.Append(Path.DirectorySeparatorChar);
    		builder.Append(hash, 6, 34);
    		builder.Append(Path.DirectorySeparatorChar);
    
    		Directory.CreateDirectory(builder.ToString());
    		if (i % 5000 == 0)
    		{
    			// write out timings every five thousand files to see if changes
    			writer.WriteLine("{0}: {1}", i, watch.Elapsed);
    			Console.WriteLine("{0}: {1}", i, watch.Elapsed);
    			watch.Reset();
    			watch.Start();
    		}
    	}
    
    	watch.Reset();
    	Console.WriteLine("Press any key to delete the directory structure...");
    	Console.ReadLine();
    	watch.Start();
    	Directory.Delete(Root, true);
    	writer.WriteLine("Delete took {0}", watch.Elapsed);
    	Console.WriteLine("Delete took {0}", watch.Elapsed);
    }
