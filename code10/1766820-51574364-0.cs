            static void Main(string[] args)
            {
                float[,,] dArray = new float[160, 304, 304];
                using (BinaryReader reader = new BinaryReader(File.OpenRead("path")))
                {
                    for(int i = 0; i < 160; i++)
                    {
                        for (int j = 0; j < 304; j++)
                        {
                            for (int k = 0; k < 304; k++)
                            {
                                dArray[i, j, k] = reader.ReadSingle();
                            }
                        }
                    }
                }
            }
