    using System;
    using System.IO;
    namespace Test
    {
        class Program
        {
            static bool GetJpegDimension(
                string fileName,
                out int width,
                out int height)
            {
                width = height = 0;
                bool found = false;
                bool eof = false;
                FileStream stream = new FileStream(
                    fileName,
                    FileMode.Open,
                    FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                while (!found || eof)
                {
                    // read 0xFF and the type
                    reader.ReadByte();
                    byte type = reader.ReadByte();
                    // get length
                    int len = 0;
                    switch (type)
                    {
                        // start and end of the image
                        case 0xD8: 
                        case 0xD9: 
                            len = 0;
                            break;
                        // restart interval
                        case 0xDD: 
                            len = 2;
                            break;
                        // the next two bytes is the length
                        default: 
                            int lenHi = reader.ReadByte();
                            int lenLo = reader.ReadByte();
                            len = (lenHi << 8 | lenLo) - 2;
                            break;
                    }
                    // EOF?
                    if (type == 0xD9)
                        eof = true;
                    // process the data
                    if (len > 0)
                    {
                        // read the data
                        byte[] data = reader.ReadBytes(len);
                        // this is what we are looking for
                        if (type == 0xC0)
                        {
                            width = data[1] << 8 | data[2];
                            height = data[3] << 8 | data[4];
                            found = true;
                        }
                    }
                }
                reader.Close();
                stream.Close();
                return found;
            }
            static void Main(string[] args)
            {
                foreach (string file in Directory.GetFiles(args[0]))
                {
                    int w, h;
                    GetJpegDimension(file, out w, out h);
                    System.Console.WriteLine(file + ": " + w + " x " + h);
                }
            }
        }
    }
