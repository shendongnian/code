            int size = 1024;
            var bytes = new List<byte[]>();
            while (true)
            {
                try
                {
                    bytes.Add(new byte[size]);
                }
                catch
                {                   
                    if (size == 1)
                    {
                        throw;
                    }
                    size = size / 2;
                }
            }
