    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Modes;
    
    namespace StreamingSicBlockCipher
    {
        /**
         * A class that implements an online Sic (segmented integer counter mode, or just counter (CTR) mode for short).
         * This class buffers one encrypted counter (representing the key stream) at a time.
         * The encryption of the counter is only performed when required, so that no key stream blocks are generated while they are not required.
         */
        public class StreamingSicBlockCipher : BufferedCipherBase
        {
            private SicBlockCipher parent;
            private int blockSize;
    
            private byte[] zeroBlock;
    
            private byte[] blockBuffer;
            private int processed;
    
            public StreamingSicBlockCipher(SicBlockCipher parent)
            {
                this.parent = parent;
                this.blockSize = parent.GetBlockSize();
    
                this.zeroBlock = new byte[blockSize];
    
                this.blockBuffer = new byte[blockSize];
                // indicates that no bytes are available: lazy generation of counter blocks (they may not be needed)
                this.processed = blockSize; 
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
                // TODO Clean up at least buffer?
                Reset();
                return result;
            }
    
            public override int GetBlockSize()
            {
                // TODO or just 1?
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
                if (processed == blockSize)
                {
                    // lazilly create a new block of key stream
                    parent.ProcessBlock(zeroBlock, 0, blockBuffer, 0);
                    processed = 0;
                }
                byte result = blockBuffer[processed++];
                return new byte[] { result };
            }
    
            public override byte[] ProcessBytes(byte[] input, int inOff, int length)
            {
                byte[] result = new byte[length];
                int inputProcessed = 0;
                while (inputProcessed < length)
                {
                    result[inputProcessed++] = (byte) (blockBuffer[processed++] ^ input[inOff + inputProcessed]);
    
                    // TODO non-optimized; the number of available bytes can be pre-calculated after all - too much branching
                    if (processed == blockSize)
                    {
                        // lazilly create a new block of key stream
                        parent.ProcessBlock(zeroBlock, 0, blockBuffer, 0);
                        processed = 0;
                    }
                }
    
                return result;
            }
    
            public override void Reset()
            {
                parent.Reset();
    
                Array.Clear(blockBuffer, 0, blockBuffer.Length);
                this.processed = blockSize;
            }
        }
    }
