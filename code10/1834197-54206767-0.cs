            // assuming we're starting with a big-endian byte[]
            // we check if we're using little endian, and if so convert the byte[] to little endian (by reversing its order) before doing the double conversion
            byte[] b = new byte[] { 64, 256-6, 256 - 51, 112, 256 - 93, 256 - 41, 10, 61 };
            bool little = BitConverter.IsLittleEndian;
            if (little)
            {
                byte[] nb = new byte[b.Length];
                for(int i =0; i<b.Length; i++)
                {
                    nb[i] = b[b.Length - 1 - i];
                }
                double doub = BitConverter.ToDouble(nb, 0);
            }
            else
            {
                double doub = BitConverter.ToDouble(b, 0);
            }
