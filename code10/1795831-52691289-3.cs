    static int getMaxIndex(byte[] data, int byteLenght)
            {
                int MaxIndex = 0;
                int signMax = data[byteLenght - 1] >> 7;// get sign
                for (int i = byteLenght; i < data.Length; i += byteLenght)
                {
                    int step = byteLenght - 1;
                    int compResult = 0;
        
                    while (compResult == 0 && step > -1)
                    {
                        if (step == byteLenght -1)
                        {
                            int signData = data[i + step] >> 7;
                            compResult = signData - signMax;
                            if (compResult == 0) compResult = data[MaxIndex + step] & 127 - data[i + step] & 127;
                        }
                        else compResult = data[MaxIndex + step] - data[i + step];
                        if (compResult < 0)
                        {
                            MaxIndex = i;
                            signMax = data[MaxIndex + step] >> 7;
                        }
                        step--;
                    }
                }
                return MaxIndex;
            }
