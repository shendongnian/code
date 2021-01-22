    using System;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Macs;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Security;
    
    namespace PBKDF2_PKCS5
    {
        class PBKDF2
        {
    
            private readonly IMac hMac = new HMac(new Sha1Digest());
    
            private void F(
                byte[] P,
                byte[] S,
                int c,
                byte[] iBuf,
                byte[] outBytes,
                int outOff)
            {
                byte[] state = new byte[hMac.GetMacSize()];
                ICipherParameters param = new KeyParameter(P);
    
                hMac.Init(param);
    
                if (S != null)
                {
                    hMac.BlockUpdate(S, 0, S.Length);
                }
    
                hMac.BlockUpdate(iBuf, 0, iBuf.Length);
    
                hMac.DoFinal(state, 0);
    
                Array.Copy(state, 0, outBytes, outOff, state.Length);
    
                for (int count = 1; count != c; count++)
                {
                    hMac.Init(param);
                    hMac.BlockUpdate(state, 0, state.Length);
                    hMac.DoFinal(state, 0);
    
                    for (int j = 0; j != state.Length; j++)
                    {
                        outBytes[outOff + j] ^= state[j];
                    }
                }
            }
    
            private void IntToOctet(
                byte[] Buffer,
                int i)
            {
                Buffer[0] = (byte)((uint)i >> 24);
                Buffer[1] = (byte)((uint)i >> 16);
                Buffer[2] = (byte)((uint)i >> 8);
                Buffer[3] = (byte)i;
            }
            // Use this function to retrieve a derived key.
            // dkLen is in octets, how much bytes you want when the function to return.
            // mPassword is the password converted to bytes.
            // mSalt is the salt converted to bytes
            // mIterationCount is the how much iterations you want to perform. 
            
   
            public byte[] GenerateDerivedKey(
                int dkLen,
                byte[] mPassword,
                byte[] mSalt,
                int mIterationCount
                )
            {
                int hLen = hMac.GetMacSize();
                int l = (dkLen + hLen - 1) / hLen;
                byte[] iBuf = new byte[4];
                byte[] outBytes = new byte[l * hLen];
    
                for (int i = 1; i <= l; i++)
                {
                    IntToOctet(iBuf, i);
    
                    F(mPassword, mSalt, mIterationCount, iBuf, outBytes, (i - 1) * hLen);
                }
    
            //By this time outBytes will contain the derived key + more bytes.
           // According to the PKCS #5 v2.0: Password-Based Cryptography Standard (www.truecrypt.org/docs/pkcs5v2-0.pdf) 
           // we have to "extract the first dkLen octets to produce a derived key".
           //I am creating a byte array with the size of dkLen and then using
           //Buffer.BlockCopy to copy ONLY the dkLen amount of bytes to it
           // And finally returning it :D
 
            byte[] output = new byte[dkLen];
            Buffer.BlockCopy(outBytes, 0, output, 0, dkLen);
            return output;
            }
    
    
        }
    }
