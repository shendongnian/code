            List<int> hashList = new List<int>(testObjectList.Count);
            for (int i = 0; i < testObjectList.Count; i++)
            {
                hashList.Add(testObjectList[i]);
            }
            hashList.Sort();
            int differentValues = 0;
            int curValue = hashList[0];
            for (int i = 1; i < hashList.Count; i++)
            {
                if (hashList[i] != curValue)
                {
                    differentValues++;
                    curValue = hashList[i];
                }
            }
            Assert.Greater(differentValues, hashList.Count/2);
  
