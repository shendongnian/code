    public static int[] RandomNumbers_Supplier()
            {
                Random R = new Random();
                int[] RandomNumbers = new int[65];
                int k = 0, Temp;
                bool IsRepetitive = false;
                while (k < 65)
                {
                    Temp = R.Next(0, 92);
                    for (int i = 0; i < 65; i++)
                    {
                        IsRepetitive = false;
                        if (RandomNumbers[i] == Temp)
                        {
                            IsRepetitive = true;
                            break;
                        }                    
                    }
                    if (!IsRepetitive)
                    {
                        RandomNumbers[k] = Temp;
                        k++;
                    }
                }
    			return(RandomNumbers)
    		}
