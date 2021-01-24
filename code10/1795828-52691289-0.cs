    static int getMaxIndex(byte[] data, int byteLenght)
                {
                    int MaxIndex = byteLenght - 1;
                    for (int i = byteLenght * 2 - 1; i < data.Length; i+= byteLenght)
                    {
                        int step = 0;
                        while (step < byteLenght)
                        {
                            int compResult = data[MaxIndex - step]- data[i - step];
                            if (compResult == 0)
                            {
                                step++;
                                continue;
                            }
                            if (compResult < 0)
                            {
                                MaxIndex = i;
                            }
                            break;
                        }
                    }
                    return MaxIndex - (byteLenght - 1);
                }
