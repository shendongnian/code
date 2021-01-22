			{
				System.IO.StreamReader aFile = System.IO.File.OpenText( @"c:\xfer\s.tab");
				string a = aFile.ReadToEnd();
				aFile.Close();
		
				int nn=0, ii;
				Console.WriteLine ("a.Length={0}", a.Length);
				while ( (ii=a.IndexOf("\n\n")) >= 0 )
				{
					nn++;
					Console.WriteLine("loop n={0}, i={1}, a={2}"
						, nn
						, ii
						, a);
					if (ii == a.IndexOf("\n\n"))
					{
						Console.WriteLine ("stuck at i={0}, a(i)={1} {2} {3}..."
							, ii
							, (int)(a.ToCharArray()[ii])
							, (int)(a.ToCharArray()[ii+1])
							, (int)(a.ToCharArray()[ii+2])
							);
						break;
					}
					a = a.Replace ("\n\n", "\n");
				}
				Console.WriteLine("done n={0}, i={1}, a={2}", nn, ii, a);
			}
