    public static async Task<List<(Guid, string)>> StreamFileAsync(this HttpRequest request, DeviceId deviceId, FileTransferInfo transferInfo)
    {
        var boundary = GetBoundary(MediaTypeHeaderValue.Parse(request.ContentType), DefaultFormOptions.MultipartBoundaryLengthLimit);
        var reader = new MultipartReader(boundary, request.Body);
        var section = await reader.ReadNextSectionAsync(_cancellationToken);
        if (section != null)
        {
            var fileSection = section.AsFileSection();
            var targetPath = transferInfo.FileTempPath;
            try
            {
                await SaveMyFile(...);
            }
			catch (OperationCanceledException){...}
            catch (Exception){...}
        }
    }
    private static async Task SaveMyFile(...)
    {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(myOtherCancellationToken);
            cts.CancelAfter(streamReadTimeoutInMs);
            var myReadTask = StreamFile(transferInfo, fileSection, cts.Token);
            await ExecuteMyTaskWithCancellation(myReadTask, cts.Token);
    }
	
    private static async Task<T> ExecuteMyTaskWithCancellation<T>(Task<T> task, CancellationToken cancellationToken)
    {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task))
                {
                    throw new OperationCanceledException(cancellationToken);
                }
            }
            return await task;
    }
	
    private static async Task<bool> StreamFile(...)
    {
            using (var outfile = new FileStream(transferInfo.FileTempPath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[DefaultCopyBufferSize];
                int read;
                while ((read = await fileSection.FileStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    await outfile.WriteAsync(buffer, 0, read);
                    transferInfo.BytesSaved = read + transferInfo.BytesSaved;
                }
                return true;
            }
    }
