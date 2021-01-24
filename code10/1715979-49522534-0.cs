            using (StreamReader sr = new StreamReader("data.txt"))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					if (line != null)
					{
						string[] items = line.Split(' ');
						decimal? x, y, z = null;
						for (int i = 1; i < items.Length; i++)
						{
							if (items[i].ToLower().StartsWith("x"))
							{
								x = decimal.Parse(items[i].Substring(1));
								Console.WriteLine($"x = {x}");
							}
							else if (items[i].ToLower().StartsWith("y"))
							{
								y = decimal.Parse(items[i].Substring(1));
								Console.WriteLine($"y = {y}");
							}
							else if (items[i].ToLower().StartsWith("z"))
							{
								z = decimal.Parse(str);
								Console.WriteLine($"y = {z}");
							}
							else
							{
								continue;
							}
						}
					}
				}
			}
