    static int getMaxIndex(byte[] data, int byteLenght)
            {
                int MaxIndex = 0;
                for (int i = byteLenght; i < data.Length; i+= byteLenght)
                {
                    int step = byteLenght - 1;
                    int compResult = 0;
                    while (compResult == 0 && step > -1)
                    {
                        compResult = data[MaxIndex + step]- data[i + step];
                        
                        if (compResult < 0)
                        {
                            MaxIndex = i;
                        }
                        step--;
                    }
                }
                return MaxIndex;
            }
