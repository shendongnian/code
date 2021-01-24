    private void OnEnable()
    {
        if (listOfDictionaryKeys==null) listOfDictionaryKeys=new List<string>();
        // this always returns null
        Debug.Log(listOfDictionaryKeys.Count);
    }
