    private static SemaphoreSlim Sema = new SemaphoreSlim(1,1);
    private async void Operation(CancellationToken ct = default)
    {
        if(pictureBox_Image.Image != null)
        {
            await Sema.WaitAsync(ct); //throws if cancelled... will not proceed
            try
            {
                await Task.Run(() => DoStuff(ct)); //DoStuff should be checking this CT too
            }
            catch{}
            finally
            {
                Sema.Release();
            }
        }
     }
