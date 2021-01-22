        private void testSwap() {
            UInt16 tmp1 = 0x0a0b;
            UInt32 tmp2 = 0x0a0b0c0d;
            SoapHexBinary shb1 = new SoapHexBinary(BitConverter.GetBytes(tmp1));
            SoapHexBinary shb2 = new SoapHexBinary(BitConverter.GetBytes(swapOctetsUInt16(tmp1)));
            Debug.WriteLine("{0}", shb1.ToString());
            Debug.WriteLine("{0}", shb2.ToString());
            SoapHexBinary shb3 = new SoapHexBinary(BitConverter.GetBytes(tmp2));
            SoapHexBinary shb4 = new SoapHexBinary(BitConverter.GetBytes(swapOctetsUInt32(tmp2)));
            Debug.WriteLine("{0}", shb3.ToString());
            Debug.WriteLine("{0}", shb4.ToString());
        }
