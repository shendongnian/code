	public static String GetOrdinal(int i)
	{
			String res = "";
			if (i > 0)
			{
					int j = (i - ((i / 100) * 100));
					if ((j == 11) || (j == 12) || (j == 13))
							res = "th";
					else
					{
							int k = i % 10;
							if (k == 1)
									res = "st";
							else if (k == 2)
									res = "nd";
							else if (k == 3)
									res = "rd";
							else
									res = "th";
					}
			}
			return i.ToString() + res;
	}
