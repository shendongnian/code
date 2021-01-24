    using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
    {
        while(sessionEnumerator.MoveNext())
        {
            var session = sessionEnumerator.Current;
            // Code
        }
    }
