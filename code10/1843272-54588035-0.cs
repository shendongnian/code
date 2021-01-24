    foreach (TestModeQuestionUI _TestModeQuestionUIRefrence in testModeQuestionExampleList)
    {
        int a = UnityEngine.Random.Range(1, 10);
        int b = UnityEngine.Random.Range(1, 10);
        _TestModeQuestionUIRefrence.SetQuestionLabel(a, b);
    }
