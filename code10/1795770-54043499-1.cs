    Task printResponses = Task.Run(async () =>
        {
            while (await streamingCall.ResponseStream.MoveNext(
                default(CancellationToken)))
            {
                if (streamingCall.ResponseStream.Current.SpeechEventType ==
     StreamingRecognizeResponse.Types.SpeechEventType.EndOfSingleUtterance)
                {
                    recognitionEnded = true;
                    Debug.WriteLine("End of detection");
                }
                foreach (var result in streamingCall.ResponseStream
                    .Current.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        Debug.WriteLine(alternative.Transcript);
                    }
                }
            }
        });
