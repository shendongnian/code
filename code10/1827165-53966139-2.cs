    try
    {
        var s = new CancellationTokenSource();
        s.CancelAfter(1000);
        byte[] bytes;
        using (var hash = MD5.Create())
        {
            using (var fs = new FileStream(f, FileMode.Open))
            {
                bytes = await hash.ComputeHashAsync(fs,
                    cancellationToken: s.Token,
                    progress: new Progress<int>(i =>
                    {
                        progressBar1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = i;
                        }));
                    }));
                MessageBox.Show(BitConverter.ToString(bytes).Replace("-", string.Empty));
            }
        }
    }
    catch (OperationCanceledException)
    {
        MessageBox.Show("Operation canceled.");
    }
