            int[] DataInts = new int[4];
            byte[] DataBytes = new byte[DataInts.Length * 4];
            // Use cryptographic random number generator to get 16 bytes random data
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            do
            {
                rng.GetBytes(DataBytes);
                // Convert 16 bytes into 4 ints
                for (int index = 0; index < DataInts.Length; index++)
                {
                    DataInts[index] = BitConverter.ToInt32(DataBytes, index * 4);
                }
                // Mask out all bits except sign bit 31 and scale bits 16 to 20 (value 0-31)
                DataInts[3] = DataInts[3] & (unchecked((int)2147483648u | 2031616));
              // Start over if scale > 28 to avoid bias 
            } while (((DataInts[3] & 1835008) == 1835008) && ((DataInts[3] & 196608) != 0));
            return new decimal(DataInts);
        }
