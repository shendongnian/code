        var inputMat = BitmapConverter.ToMat(myBitmap);
        var kernel = OpenCvSharp.InputArray.Create(
            new float[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
            );
        for (int i = 0; i < inputMat.Channels(); i++)
        {
            var c1 = inputMat.ExtractChannel(i);
            var c2 = c1.Filter2D(inputMat.Type(), kernel);
            c1.Dispose();
            c2.InsertChannel(inputMat, i);
            c2.Dispose();
        }
