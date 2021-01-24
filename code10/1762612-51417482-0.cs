    await Dispatcher.InvokeAsync(() => {while (await streamingCall.ResponseStream.MoveNext(default(CancellationToken)))
            {
                foreach (var result in streamingCall.ResponseStream
                    .Current.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        Console.WriteLine(alternative.Transcript);
                        //Textbox1.Text = alternative.Transcript;
                    }
                }
            }});    
