        static string chex(byte e)                  // Convert a byte to a string representing that byte in hexadecimal
        {
            string r = "";
            string chars = "0123456789ABCDEF";
            r += chars[e >> 4];
            return r += chars[e &= 0x0F];
        }           // Easy enough...
        static byte CRAZY_BYTE(string t, int i)     // Take a byte, if zero return zero, else throw exception (i=0 means false, i>0 means true)
        {
            if (i == 0) return 0;
            throw new Exception(t);
        }
        static byte hbyte(string e)                 // Take 2 characters: these are hex chars, convert it to a byte
        {                                           // WARNING: This code will make small children cry. Rated R.
            e = e.ToUpper(); // 
            string msg = "INVALID CHARS";           // The message that will be thrown if the hex str is invalid
            byte[] t = new byte[]                   // Gets the 2 characters and puts them in seperate entries in a byte array.
            {                                       // This will throw an exception if (e.Length != 2).
                (byte)e[CRAZY_BYTE("INVALID LENGTH", e.Length ^ 0x02)], 
                (byte)e[0x01] 
            };
            for (byte i = 0x00; i < 0x02; i++)      // Convert those [ascii] characters to [hexadecimal] characters. Error out if either character is invalid.
            {
                t[i] -= (byte)((t[i] >= 0x30) ? 0x30 : CRAZY_BYTE(msg, 0x01));                                  // Check for 0-9
                t[i] -= (byte)((!(t[i] < 0x0A)) ? (t[i] >= 0x11 ? 0x07 : CRAZY_BYTE(msg, 0x01)) : 0x00);        // Check for A-F
            }           
            return t[0x01] |= t[0x00] <<= 0x04;     // The moment of truth.
        }
