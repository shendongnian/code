    loads = (await Task.WhenAll(files.Select(file =>
    {
        return LoadAsync(file).ContinueWith(t =>
        {
            if (t.IsFaulted) NotifyUser(t.Exception.Message, NotifyType.ErrorMessage);
            if (t.IsCanceled) NotifyUser("operation was canceled.", NotifyType.ErrorMessage);
            if (t.Status == TaskStatus.RanToCompletion)
            {
                LoadedFiles.Add(file.Path);
                return t.Result;
            }
            return null;
        }, scheduler);
    }))).Where(x => x != null).ToArray();
