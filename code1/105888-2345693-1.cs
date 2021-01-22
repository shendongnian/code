        private static int[] _bitcounts = InitializeBitcounts();
        private static int GetCardinality(BitArray bitArray)
        {
            uint[] array = (uint[])bitArray.GetType().GetField("m_array", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(bitArray);
            int count = 0;
            foreach (uint value in array)
            {
                count += _bitcounts[value & 65535] + _bitcounts[(value >> 16) & 65535];           
            }
            return count;
        }
        private static int[] InitializeBitcounts()
        {
            int[] bitcounts = new int[65536];
            int position1 = -1;
            int position2 = -1;
            //
            // Loop through all the elements and assign them.
            //
            for (int i = 1; i < 65536; i++, position1++)
            {
                //
                // Adjust the positions we read from.
                //
                if (position1 == position2)
                {
                    position1 = 0;
                    position2 = i;
                }
                bitcounts[i] = bitcounts[position1] + 1;
            }
            return bitcounts;
        }
