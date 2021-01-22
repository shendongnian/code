		protected static int LongestPalindrome(string str)
		{
			int i = 0; 
			int j = 1;
			int oldJ = 1;
			int intMax = 1;
			int intCount = 0;
			if (str.Length == 0) return 0;
			if (str.Length == 1) return 1;
			int[] intDistance = new int[2] {0,1};
			for( int k = 0; k < intDistance.Length; k++ ){
				j = 1 + intDistance[k];
				oldJ = j;
				intCount = 0;
				i = 0;
				while (j < str.Length)
				{
					
					if (str[i].Equals(str[j]))
					{
						oldJ = j;
						intCount = 2 + intDistance[k];
						i--;
						j++;
						while (i >= 0 && j < str.Length)
						{
							if (str[i].Equals(str[j]))
							{
								intCount += 2;
								i--;
								j++;
								continue;
							}
							else
							{
								break;
							}
						}
						intMax = getMax(intMax, intCount);
						j = oldJ + 1;
						i = j - 1 - intDistance[k];
					}
					else
					{
						i++;
						j++;
					}
				}
			}
			
			return intMax;
		}
		protected static int getMax(int a, int b)
		{
			if (a > b) return a; return b;
		}
