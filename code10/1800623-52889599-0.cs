    private static void RotatePoints(float[] x, float[] y, float cosAngle, float sinAngle)
    {
        var chunkSize = Vector<float>.Count;
        var resultX = new float[x.Length];
        var resultY = new float[x.Length];
        Vector<float> vectorChunk1;
        Vector<float> vectorChunk2;
        Vector<float> vcosAngle = new Vector<float>(cosAngle);
        Vector<float> vsinAngle = new Vector<float>(sinAngle);
        int i;
        for (i = 0; i + chunkSize - 1 < x.Length; i += chunkSize)
        {
            vectorChunk1 = new Vector<float>(x, i);
            vectorChunk2 = new Vector<float>(y, i);
            Vector.Subtract(Vector.Multiply(vectorChunk1, vcosAngle), Vector.Multiply(vectorChunk2, vsinAngle)).CopyTo(resultX, i);
            Vector.Add(Vector.Multiply(vectorChunk1, vsinAngle), Vector.Multiply(vectorChunk2, vcosAngle)).CopyTo(resultY, i);
        }
        for (; i < x.Length; i++)
        {
            resultX[i] = x[i] * cosAngle - y[i] * sinAngle;
            resultY[i] = x[i] * sinAngle + y[i] * cosAngle;
        }
    }
