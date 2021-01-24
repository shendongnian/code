        private float[,,,] TensorToFLoats(TFTensor tensor)
        {
            IntPtr resData = tensor.Data;
            UIntPtr dataSize = tensor.TensorByteSize;
            byte[] s_ImageBuffer = new byte[(int)dataSize];
            System.Runtime.InteropServices.Marshal.Copy(resData, s_ImageBuffer, 0, (int)dataSize);
            int floatsLength = s_ImageBuffer.Length / 4;
            float[] floats = new float[floatsLength];
            for (int n = 0; n < s_ImageBuffer.Length; n += 4)
            {
                floats[n / 4] = BitConverter.ToSingle(s_ImageBuffer, n);
            }
            float[,,,] result = new float[1, 128, 128, 16];
            int i = 0;
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    for (int p = 0; p < 16; p++)
                    {
                        result[0, y, x, p] = floats[i++];
                    }
                }
            }
            return result;
        }
