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
                PNG png = new PNG(READ_FILENAME, WRITE_FILENAME);
            }
        }
        class PNG
        {
            byte[] header;
            byte[] ident = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
            byte[] TNS = { 0x74, 0x52, 0x4E, 0x53 }; //"tRNS"
            public PNG(string inFilename, string outFilename)
            {
                Stream inStream = File.OpenRead(inFilename);
                BinaryReader reader = new BinaryReader(inStream);
                Stream outStream = File.Open(outFilename, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(outStream);
                Boolean foundIDAT = false;
                
                header = reader.ReadBytes(8);
                if ((header.Length != ident.Length) || !(header.Select((x,i) => (x == ident[i])).All(x => x)))
                {
                    Console.WriteLine("File is not PNG");
                    return;
                }
                writer.Write(header);
                while (inStream.Position < inStream.Length)
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
                    string chunkName = Encoding.ASCII.GetString(chunkType);
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
                    uint crc = GetCRC(chunkType, data);
                    UInt32 ExpectedCRC = (UInt32)((CRC[0] << 24) | (CRC[1] << 16) | (CRC[2] << 8) | CRC[3]);
                    if (crc != ExpectedCRC)
                    {
                        Console.WriteLine("Bad CRC");
                    }
                    switch (chunkName)
                    {
                        case "IHDR" :
                            writer.Write(byteLength);
                            writer.Write(chunkType);
                            writer.Write(data);
                            Header chunkHeader = new Header(data);
                            chunkHeader.PrintImageHeader();
                            break;
                        case "IDAT" :
                            if (!foundIDAT)
                            {
                                //add transparency header before first IDAT header
                                byte[] tnsHeader = CreateTransparencyHeader();
                                writer.Write(tnsHeader);
                                foundIDAT = true;
                            }
                            writer.Write(byteLength);
                            writer.Write(chunkType);
                            writer.Write(data);
                            break;
                        default :
                            writer.Write(byteLength);
                            writer.Write(chunkType);
                            writer.Write(data);
     
                            break;
                    }
                    writer.Write(CRC);
                }
                reader.Close();
                writer.Flush();
                writer.Close();
     
            }
            public byte[] CreateTransparencyHeader()
            {
                byte[] white = { 0, 0 };
                List<byte> header = new List<byte>();
                byte[] length = { 0, 0, 0, 2 };  //length is just two bytes
                header.AddRange(length);
                header.AddRange(TNS);
                header.AddRange(white);
                UInt32 crc = GetCRC(TNS, white);
                byte[] crcBytes = { (byte)((crc >> 24) & 0xFF), (byte)((crc >> 16) & 0xFF), (byte)((crc >> 8) & 0xFF), (byte)(crc & 0xFF) };
                header.AddRange(crcBytes);
                return header.ToArray();
            }
            public uint GetCRC(byte[] type, byte[] bytes)
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
        public class Header
        {
            public UInt32 width { get; set; }
            public UInt32 height { get; set; }
            byte[] widthBytes { get; set; }
            byte[] heightBytes { get; set; }
            public byte depth { get; set; }
            public byte colourType { get; set; }
            public byte compressionMethod { get; set; }
            public byte filterMethod { get; set; }
            public byte interlaceMethod { get; set; }
            public Header(byte[] bytes)
            {
                UInt32 width = (UInt32)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
                UInt32 height = (UInt32)((bytes[4] << 24) | (bytes[5] << 16) | (bytes[6] << 8) | bytes[7]);
                
                widthBytes = new byte[4];
                Array.Copy(bytes, widthBytes, 4);
                heightBytes = new byte[4];
                Array.Copy(bytes, 4, heightBytes, 0, 4);
                depth = bytes[8];
                colourType = bytes[9];
                compressionMethod = bytes[10];
                filterMethod = bytes[11];
                interlaceMethod = bytes[12];
            }
            public void PrintImageHeader()
            {
               Console.WriteLine("Width = '{0}', Height = '{1}', Bit Depth = '{2}', Colour Type = '{3}', Compression Method = '{4}', Filter Medthod = '{5}', Interlace Method = '{6}'",
                   width.ToString(),
                   height.ToString(),
                   depth.ToString(),
                   ((COLOUR_TYPE)colourType).ToString(),
                   compressionMethod.ToString(),
                   filterMethod.ToString(),
                   interlaceMethod.ToString()
                       );
            
             }
            public byte[] GetHeader()
            {
                List<byte> header = new List<byte>();
                header.AddRange(widthBytes);
                header.AddRange(heightBytes);
                header.Add(depth);
                header.Add(colourType);
                header.Add(compressionMethod);
                header.Add(filterMethod);
                header.Add(interlaceMethod);
                return header.ToArray();
            }
        }
        public enum COLOUR_TYPE
        {
            GRAY_SCALE = 0,
            TRUE_COLOUR = 2,
            INDEXED_COLOUR = 3,
            GREY_SCALE_ALPHA = 4,
            TRUE_COLOUR_ALPHA = 6
        }
    }
