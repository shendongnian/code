    before reading request body need to EnableBuffering and after that need add Body.Position = 0
    
    Solution 1:
    
    
    
    context.Request.EnableBuffering();
    
        // Leave the body open so the next middleware can read it.
        using (var reader = new StreamReader(
            context.Request.Body,
            encoding: Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            bufferSize: bufferSize,
            leaveOpen: true))
        {
            var body = await reader.ReadToEndAsync();
            // Do some processing with body…
    
            // Reset the request body stream position so the next middleware can read it
            context.Request.Body.Position = 0;
        }
     
    solution 2:
    
     private async Task<string> FormatRequest(HttpRequest request)
            {
                request.EnableBuffering();
                var requestBody = await ReadBodyFromPipeReader(request.BodyReader);
                request.Body.Position = 0;
                return requestBody;
            }
    
     private async Task<string> ReadBodyFromPipeReader(PipeReader reader)
            {
                StringBuilder stringBuilder = new StringBuilder();
                while (true)
                {
                    // await some data being available
                    ReadResult read = await reader.ReadAsync();
                    ReadOnlySequence<byte> buffer = read.Buffer;
                    // check whether we've reached the end
                    // and processed everything
                    if (buffer.IsEmpty && read.IsCompleted)
                        break; // exit loop
    
                    // process what we received
                    foreach (var segment in buffer)
                    {
                        string asciString = Encoding.ASCII.GetString(
                            segment.Span);
                        stringBuilder.Append(asciString);
                    }
                    // tell the pipe that we used everything   
                    reader.AdvanceTo(buffer.Start, buffer.End);
                    if (read.IsCompleted)
                    {
                        break;
                    }
    
                }
                return Convert.ToString(stringBuilder);
            }
