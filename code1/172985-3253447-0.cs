    private void RefactorizedFunction(ComboBox cmb, ComboBox cbGame, ref int success, ref int botch, int value, int maxsuxcess)
        {
            
                var arraySize = (int)cmb.SelectedIndex;
                int[] refArray = randomNumber(value, arraySize);
                foreach (int i in refArray)
                {
                    if (cbGame.SelectedIndex == 1)
                    {
                        if (refArray[i] >= 2)
                        {
                            success++;
                        }
                        if (refArray[i] == 1)
                        {
                            botch++;
                        }
                    }
                    if (cbGame.SelectedIndex != 2) continue;
                    if (refArray[i] >= maxsuxcess)
                    {
                        success++;
                    }
                    if (refArray[i] == 1)
                    {
                        botch++;
                    }
                }
        }
