    IEnumerator Randomizer()
    {
        PreList = PreList.OrderBy(C => Rnd.Next()).ToArray();
        foreach (var item in PreList)
        {
            Debug.Log(item.ToString());
            if (item == 1)
            {
                yield return StartCoroutine(OneMethod());
            }
            if (item == 2)
            {
                yield return StartCoroutine(TwoMethod());
    
            }
            if (item == 3)
            {
                yield return StartCoroutine(ThreeMethod());
            }
        }
    }
