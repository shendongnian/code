        /// <summary>
        ///  Read in wav file and put into Left and right array
        /// </summary>
        /// <param name="fileName"></param>
        private void ReadWavfiles(string fileName)
        {
            byte[] fa = File.ReadAllBytes(fileName);
            int startByte = 0;
            // look for data header
            {
                var x = 0;
                while (x < fa.Length)
                {
                    if (fa[x]     == 'd' && fa[x + 1] == 'a' && 
                        fa[x + 2] == 't' && fa[x + 3] == 'a')
                    {
                        startByte = x + 8;
                        break;
                    }
                    x++;
                }
            }
            // Split out channels from sample
            var sLeft = new short[fa.Length / 4];
            var sRight = new short[fa.Length / 4];
            {
                var x = 0;
                var length = fa.Length;
                for (int s = startByte; s < length; s = s + 4)
                {
                    sLeft[x] = (short)(fa[s + 1] * 0x100 + fa[s]);
                    sRight[x] = (short)(fa[s + 3] * 0x100 + fa[s + 2]);
                    x++;
                }
            }
            // do somthing with the wav data in sLeft and sRight
        }
