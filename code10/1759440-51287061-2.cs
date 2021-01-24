    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Modes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SicStream
    {
        public class SicStreamCipher : IStreamCipher
        {
            private SicBlockCipher parent;
            private int blockSize;
    
            private byte[] zeroBlock;
    
            private byte[] blockBuffer;
            private int processed;
    
            public SicStreamCipher(SicBlockCipher parent)
            {
                this.parent = parent;
                this.blockSize = parent.GetBlockSize();
    
                this.zeroBlock = new byte[blockSize];
    
                this.blockBuffer = new byte[blockSize];
                // indicates that no bytes are available: lazy generation of counter blocks (they may not be needed)
                this.processed = blockSize;
            }
    
            public string AlgorithmName
            {
                get
                {
                    return parent.AlgorithmName;
                }
            }
    
            public void Init(bool forEncryption, ICipherParameters parameters)
            {
                parent.Init(forEncryption, parameters);
    
                Array.Clear(blockBuffer, 0, blockBuffer.Length);
                processed = blockSize;
            }
    
            public void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
            {
                int inputProcessed = 0;
                while (inputProcessed < length)
                {
                    // TODO non-optimized; the number of available bytes can be pre-calculated after all - too much branching
                    if (processed == blockSize)
                    {
                        // lazilly create a new block of key stream
                        parent.ProcessBlock(zeroBlock, 0, blockBuffer, 0);
                        processed = 0;
                    }
    
                    output[outOff + inputProcessed] = (byte)(input[inOff + inputProcessed] ^ blockBuffer[processed]);
    
                    processed++;
                    inputProcessed++;
                }
            }
    
            public void Reset()
            {
                parent.Reset();
    
                Array.Clear(blockBuffer, 0, blockBuffer.Length);
                this.processed = blockSize;
            }
    
            public byte ReturnByte(byte input)
            {
                if (processed == blockSize)
                {
                    // lazilly create a new block of key stream
                    parent.ProcessBlock(zeroBlock, 0, blockBuffer, 0);
                    processed = 0;
                }
                return (byte)(input ^ blockBuffer[processed++]);
            }
        }
    }
