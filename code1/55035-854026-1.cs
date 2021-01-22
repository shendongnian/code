    using System;
    
    public static class Parser
    {    
        static void Main()
        {
            string hex = "0xBAC893CAB8B7FE03C927417A2A3F6A6"
                         + "0BD30FF35E250011CB25507EBFCD5223B";
            byte[] parsed = ParseHex(hex);
            // Just for confirmation...
            Console.WriteLine(BitConverter.ToString(parsed));
        }
        
        public static byte[] ParseHex(string hex)
        {
            if ((hex.Length % 2) != 0)
            {
                throw new ArgumentException("Invalid length: " + hex.Length);
            }
            if (hex.StartsWith("0x"))
            {
                // This is inefficient, but simple. Could optimise against it
                // if necessary
                hex = hex.Substring(2);
            }
            byte[] ret = new byte[hex.Length/2];
            for (int i=0; i < ret.Length; i++)
            {
                ret[i] = (byte) ((ParseNybble(hex[i*2]) << 4) 
                                 | ParseNybble(hex[i*2+1]));
            }
            return ret;
        }
        
        static int ParseNybble(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c-'0';
            }
            if (c >= 'A' && c <= 'F')
            {
                return c-'A'+10;
            }
            if (c >= 'a' && c <= 'f')
            {
                return c-'a'+10;
            }
            throw new ArgumentException("Invalid hex digit: " + c);
        }
    }
