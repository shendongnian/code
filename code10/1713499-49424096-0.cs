    public void  GenerateLettersAtStart()
    {
        int nbVowels = (int)Random.Range(2, 5);
        int nbConsonants = 10-nbVowels;
        for (int i = 0; i < nbConsonants; i++)
        {
            wordRan.wordsStore.Clear();
            a = UnityEngine.Random.Range(0,consonants.Length);
            availablesetConsonants [i].GetComponent<TextMesh> ().text  = 
            consonants[a].ToString();
        }
   
        for (int j = 0; j < nbVowels; j++)
        {
            wordRan.wordsStore.Clear();
            b = UnityEngine.Random.Range(0, vowels.Length);
            availablesetVowels [j].GetComponent<TextMesh> ().text = 
           vowels[b].ToString();
        }
    }
