    public static void ReadAllBytesInCoroutine(MonoBehaviour context, string filePath, Action<ReadBytesInCoroutineResult> onComplete)
    {
        context.StartCoroutine(ReadFileBytesAndTakeAction(filePath, onComplete));
    }
    private static IEnumerator ReadFileBytesAndTakeAction(string filePath, Action<ReadBytesInCoroutineResult> followingAction)
    {
        WWW reader = null;
        
        try
        {
            reader = new WWW(filePath);
        }
        catch(Exception exception)
        {
            followingAction.Invoke(ReadBytesInCoroutineResult.Failure(exception));
        }
        while (reader != null && !reader.isDone)
        {
            yield return null;
        }
        followingAction.Invoke(ReadBytesInCoroutineResult.Success(reader.bytes));
    }
