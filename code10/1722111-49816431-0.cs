        semaphore = new SemaphoreSlim(degreeOfParallelism);
        cts = new CancellationTokenSource();
        var postVMs = await Task.WhenAll(
        posts.Select(async p => 
        {
            await semaphore.WaitAsync(cts.Token).ConfigureAwait(false);
            cts.Token.ThrowIfCancellationRequested();
            new PostViewModel
            {
                PostId = p.Id,
                PostContent = p.Content,
                PostTitle = p.Title,
                WriterAvatarUri = fileService.GetFileUri(p.Writer.Profile.AvatarId, Url),
                WriterFullName = p.Writer.Profile.FullName,
                WriterId = p.WriterId,
                Liked = await postService.IsPostLikedByUserAsync(p.Id, UserId),// TODO this takes too long!!!!
            }
            semaphore.Release();
        }));
