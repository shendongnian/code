    int[] refArray = randomNumber(value, arraySize);
                foreach (int i in refArray)
                {
    
                    if (cbGame.SelectedIndex == 1)
                    {
                        if (refArray[i] >= 2)
                        {
                            success4++;
                        }
                        if (refArray[i] == 1)
                        {
                            botch4++;
                        }
                    }
