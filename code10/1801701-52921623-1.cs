        public void choose()
    {
        duplicates = new HashSet<string>();
        while (rounds < insertNum)
    	{
            key = "(" + itemList[i].ToString() + " " + itemList[j].ToString() + ")";
            while (duplicates.Contains(key))
    		{
                i = UnityEngine.Random.Range(0, allNumbers - 2);
                j = UnityEngine.Random.Range(i, allNumbers - 1);
                key = "(" + itemList[i].ToString() + " " + itemList[j].ToString() + ")";
            }
            duplicates.Add(key); // the one is just a filler variable
    
            if (buttonOneBool) { //bool def is in another script, ignore
                finalList[itemList[i].ToString()] = valueList[i] += 2;
                finalList[itemList[j].ToString()] = valueList[j] -= 2;
                i = UnityEngine.Random.Range(0, n - 1);
                j = UnityEngine.Random.Range(0, n - 1);
            } else if (buttonTwoBool) {
                finalList[itemList[i].ToString()] = valueList[i] -= 2;
                finalList[itemList[j].ToString()] = valueList[j] += 2;
                i = UnityEngine.Random.Range(0, n - 1);
                j = UnityEngine.Random.Range(0, n - 1);
            } else if (buttonThreeBool) {
                finalList[itemList[i].ToString()] = valueList[i] -= 1;
                finalList[itemList[j].ToString()] = valueList[j] -= 1;
                i = UnityEngine.Random.Range(0, n - 1);
                j = UnityEngine.Random.Range(0, n - 1);
            } else if (buttonFourBool) {
                finalList[itemList[i].ToString()] = valueList[i] += 1;
                finalList[itemList[j].ToString()] = valueList[j] += 1;
                i = UnityEngine.Random.Range(0, n - 1);
                j = UnityEngine.Random.Range(0, n - 1);
            }
            break;
        }
    }
