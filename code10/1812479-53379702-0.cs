    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace PNG_Tool
    {
        class Program
        {
            const string READ_FILENAME = @"c:\temp\untitled.png";
            const string WRITE_FILENAME = @"c:\temp\untitled1.png";
            static void Main(string[] args)
            {
                PNG png = new PNG(READ_FILENAME);
                png.Write(WRITE_FILENAME);
            }
        }
        class PNG
        {
            byte[] header;
            byte[] ident = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
            List<Chunk> chunks = new List<Chunk>();
            public PNG(string filename)
            {
                Stream stream = File.OpenRead(filename);
                BinaryReader reader = new BinaryReader(stream);
                header = reader.ReadBytes(8);
                if ((header.Length != ident.Length) || !(header.Select((x,i) => (x == ident[i])).All(x => x)))
                {
                    Console.WriteLine("File is not PNG");
                    return;
                }
                while (stream.Position < stream.Length)
                {
                    byte[] byteLength = reader.ReadBytes(4);
                    if (byteLength.Length < 4)
                    {
                        Console.WriteLine("Unexpected End Of File");
                        return;
                    }
                    UInt32 length = (UInt32)((byteLength[0] << 24) | (byteLength[1] << 16) | (byteLength[2] << 8) | byteLength[3]);
                    byte[] chunkType = reader.ReadBytes(4);
                    if (chunkType.Length < 4)
                    {
                        Console.WriteLine("Unexpected End Of File");
                        return;
                    }
                    byte[] data = reader.ReadBytes((int)length);
                    if (data.Length < length)
                    {
                        Console.WriteLine("Unexpected End Of File");
                        return;
                    }
                    byte[] CRC = reader.ReadBytes(4);
                    if (CRC.Length < 4)
                    {
                        Console.WriteLine("Unexpected End Of File");
                        return;
                    }
                    Chunk newChunk = new Chunk();
                    chunks.Add(newChunk);
                    newChunk.length = length;
                    newChunk.byteLength = byteLength;
                    newChunk.type = chunkType;
                    newChunk.bytes = data;
                    newChunk.CRC = CRC;
                    newChunk.CunkName = Encoding.ASCII.GetString(chunkType);
                    uint crc = newChunk.GetCRC();
                    UInt32 ExpectedCRC = (UInt32)((newChunk.CRC[0] << 24) | (newChunk.CRC[1] << 16) | (newChunk.CRC[2] << 8) | newChunk.CRC[3]);
                    if (crc != ExpectedCRC)
                    {
                        Console.WriteLine("Bad CRC");
                    }
                }
            }
            public void Write(string filename)
            {
                Stream stream = File.OpenWrite(filename);
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(header);
                foreach(Chunk chunk in chunks)
                {
                    writer.Write(chunk.byteLength);
                    writer.Write(chunk.type);
                    writer.Write(chunk.bytes);
                    writer.Write(chunk.CRC);
                }
                stream.Flush();
                stream.Close();
            }
        }
        public class Chunk
        {
            public UInt32 length { get; set; }
            public byte[] byteLength { get; set; }
            public byte[] type { get; set;}
            public byte[] bytes { get; set; }
            public byte[] CRC { get;set;}
            public string CunkName { get; set; }
            public uint GetCRC()
            {
                uint crc = 0xffffffff; /* CRC value is 32bit */
                //crc = CRC32(byteLength, crc);
                crc = CRC32(type, crc);
                crc = CRC32(bytes, crc);
                crc = Reflect(crc, 32);
                crc ^= 0xFFFFFFFF;
                return crc;
                
            }
            public uint CRC32(byte[] bytes, uint crc)
            {
                const uint polynomial = 0x04C11DB7; /* divisor is 32bit */
                foreach (byte b in bytes)
                {
                    crc ^= (uint)(Reflect(b, 8) << 24); /* move byte into MSB of 32bit CRC */
                    for (int i = 0; i < 8; i++)
                    {
                        if ((crc & 0x80000000) != 0) /* test for MSB = bit 31 */
                        {
                            crc = (uint)((crc << 1) ^ polynomial);
                        }
                        else
                        {
                            crc <<= 1;
                        }
                    }
                }
                return crc;
            }
            static public UInt32 Reflect(UInt32 data, int size)
            {
                UInt32 output = 0;
                for (int i = 0; i < size; i++)
                {
                    UInt32 lsb = data & 0x01;
                    output = (UInt32)((output << 1) | lsb);
                    data >>= 1;
                }
                return output;
            }
        }
    }
