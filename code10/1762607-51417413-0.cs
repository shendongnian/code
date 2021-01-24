    async Task DisplayResponses(IAsyncEnumerator<StreamingRecognizeResponse> responses)
    {
        while (await responses.MoveNext(default(CancellationToken)))
        {
            foreach (var result in responses.Current.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Textbox1.Text = alternative.Transcript;
                }
            }
        }
    }
