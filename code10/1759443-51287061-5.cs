    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Modes;
    
    namespace SicStream
    {
        /**
         * A class that implements an online Sic (segmented integer counter mode, or just counter (CTR) mode for short).
         * This class buffers one encrypted counter (representing the key stream) at a time.
         * The encryption of the counter is only performed when required, so that no key stream blocks are generated while they are not required.
         */
        public class StreamingSicBlockCipher : BufferedCipherBase
        {
            private SicStreamCipher parent;
            private int blockSize;
    
            public StreamingSicBlockCipher(SicBlockCipher parent)
            {
                this.parent = new SicStreamCipher(parent);
                this.blockSize = parent.GetBlockSize();
            }
    
            public override string AlgorithmName
            {
                get
                {
                    return parent.AlgorithmName;
                }
            }
    
            public override byte[] DoFinal()
            {
                // returns no bytes at all, as there is no input
                return new byte[0];
            }
    
            public override byte[] DoFinal(byte[] input, int inOff, int length)
            {
                byte[] result = ProcessBytes(input, inOff, length);
                Reset();
                return result;
            }
    
            public override int GetBlockSize()
            {
                return blockSize;
            }
    
            public override int GetOutputSize(int inputLen)
            {
                return inputLen;
            }
    
            public override int GetUpdateOutputSize(int inputLen)
            {
                return inputLen;
            }
    
            public override void Init(bool forEncryption, ICipherParameters parameters)
            {
                parent.Init(forEncryption, parameters);
            }
    
            public override byte[] ProcessByte(byte input)
            {
                return new byte[] { parent.ReturnByte(input) };
            }
    
            public override byte[] ProcessBytes(byte[] input, int inOff, int length)
            {
                byte[] result = new byte[length];
                parent.ProcessBytes(input, inOff, length, result, 0);
                return result;
            }
    
            public override void Reset()
            {
                parent.Reset();
            }
        }
    }
