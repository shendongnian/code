    using System;
    using System.Text;
    public class CFMXCompat
    {
        private string m_Key;
        private uint m_LFSR_A = 0x13579bdf;
        private uint m_LFSR_B = 0x2468ace0;
        private uint m_LFSR_C = 0xfdb97531;
        private uint m_Mask_A = 0x80000062;
        private uint m_Mask_B = 0x40000020;
        private uint m_Mask_C = 0x10000002;
        private uint m_Rot0_A = 0x7fffffff;
        private uint m_Rot0_B = 0x3fffffff;
        private uint m_Rot0_C = 0xfffffff;
        private uint m_Rot1_A = 0x80000000;
        private uint m_Rot1_B = 0xc0000000;
        private uint m_Rot1_C = 0xf0000000;
        public byte[] TransformString(string key, byte[] inBytes)
        {
            SetKey(key);
            int length = inBytes.Length;
            byte[] outBytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                outBytes[i] = TransformByte(inBytes[i]);
            }
            return outBytes;
        }
        private byte TransformByte(byte target)
        {
            byte crypto = 0;
            int b = (int)(m_LFSR_B & 1);
            int c = (int)(m_LFSR_C & 1);
            for (int i = 0; i < 8; i++)
            {
                if (0 != (m_LFSR_A & 1))
                {
                    m_LFSR_A = m_LFSR_A ^ m_Mask_A >> 1 | m_Rot1_A;
                    if (0 != (m_LFSR_B & 1))
                    {
                        m_LFSR_B = m_LFSR_B ^ m_Mask_B >> 1 | m_Rot1_B;
                        b = 1;
                    }
                    else
                    {
                        m_LFSR_B = m_LFSR_B >> 1 & m_Rot0_B;
                        b = 0;
                    }
                }
                else
                {
                    m_LFSR_A = m_LFSR_A >> 1 & m_Rot0_A;
                    if (0 != (m_LFSR_C & 1))
                    {
                        m_LFSR_C = m_LFSR_C ^ m_Mask_C >> 1 | m_Rot1_C;
                        c = 1;
                    }
                    else
                    {
                        m_LFSR_C = m_LFSR_C >> 1 & m_Rot0_C;
                        c = 0;
                    }
                }
                crypto = (byte)(crypto << 1 | b ^ c);
            }
            target ^= crypto;
            return target;
        }
        private void SetKey(string key)
        {
            int i = 0;
            m_Key = key;
            if (String.IsNullOrEmpty(key))
                key = "Default Seed";
            char[] seed = new char[key.Length >= 12 ? key.Length : 12];
            char[] keyChars = key.ToCharArray();
            if (seed.Length >= 12)
            {
                seed = keyChars;
            }
            else
            {
                int originalLength = m_Key.Length;
                for (i = 0; originalLength + i < 12; i++)
                {
                    seed[originalLength + i] = seed[i];
                }
            }
            for (i = 0; i < 4; i++)
            {
                m_LFSR_A = (m_LFSR_A <<= 8) | seed[i + 4];
                m_LFSR_B = (m_LFSR_B <<= 8) | seed[i + 4];
                m_LFSR_C = (m_LFSR_C <<= 8) | seed[i + 4];
            }
            if (0 == m_LFSR_A) m_LFSR_A = 0x13579bdf;
            if (0 == m_LFSR_B) m_LFSR_B = 0x2468ace0;
            if (0 == m_LFSR_C) m_LFSR_C = 0xfdb97531;
        }
    }
