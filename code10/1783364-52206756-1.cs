    try
    {
        using (cts = cts ?? new CancellationTokenSource())
            await Task.Delay(3000, cts.Token).ContinueWith(tr =>
            {
                if (!tr.IsCanceled)
                {
                    var st = searchText;
                    //Do search here
                }
            });
    }
    finally { cts = null; }
