        private byte[] trimByte(byte[] input)
        {
            if (input.Length > 1)
            {
                int byteCounter = input.Length - 1;
                while (input[byteCounter] == 0x00)
                {
                    byteCounter--;
                }
                byte[] rv = new byte[(byteCounter + 1)];
                for (int byteCounter1 = 0; byteCounter1 < (byteCounter + 1); byteCounter1++)
                {
                    rv[byteCounter1] = input[byteCounter1];
                }
                return rv;
            }
           
