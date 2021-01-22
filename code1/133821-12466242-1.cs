        Task<MemoryStream> Task1 = Task.Factory.StartNewSta(() =>
                {
                    /* use wpf here*/
                    BitmapEncoder PngEncoder =
                        new PngBitmapEncoder();
                    PngEncoder.Frames.Add(BitmapFrame.Create(Render));
                    //save to memory stream 
                    var Ms = new MemoryStream();
                    PngEncoder.Save(Ms);                
                    return Ms;
              });
        Task.WaitAll(Task1);
        return Task1.Result;
