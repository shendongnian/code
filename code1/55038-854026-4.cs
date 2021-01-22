        // Omitted for brevity... I'm sure you get the gist
        private static readonly int[] NybbleLookup = BuildLookup();
        private int ParseNybble(char c)
        {
            if (c > 'f')
            {
                throw new ArgumentException("Invalid hex digit: " + c);
            }
            int ret = NybbleLookup[c];
            if (ret == -1)
            {
                throw new ArgumentException("Invalid hex digit: " + c);
            }
            return ret;
        }
