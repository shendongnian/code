    public static byte[] FromHex(byte[] hexData)
        {
            if (hexData == null)
            {
                throw new ArgumentNullException("hexData");
            }
            if (hexData.Length < 2 || (hexData.Length / (double)2 != Math.Floor(hexData.Length / (double)2)))
            {
                throw new Exception("Illegal hex data, hex data must be in two bytes pairs, for example: 0F,FF,A3,... .");
            }
            MemoryStream retVal = new MemoryStream(hexData.Length / 2);
            // Loop hex value pairs
            for (int i = 0; i < hexData.Length; i += 2)
            {
                byte[] hexPairInDecimal = new byte[2];
                // We need to convert hex char to decimal number, for example F = 15
                for (int h = 0; h < 2; h++)
                {
                    if (((char)hexData[i + h]) == '0')
                    {
                        hexPairInDecimal[h] = 0;
                    }
                    else if (((char)hexData[i + h]) == '1')
                    {
                        hexPairInDecimal[h] = 1;
                    }
                    else if (((char)hexData[i + h]) == '2')
                    {
                        hexPairInDecimal[h] = 2;
                    }
                    else if (((char)hexData[i + h]) == '3')
                    {
                        hexPairInDecimal[h] = 3;
                    }
                    else if (((char)hexData[i + h]) == '4')
                    {
                        hexPairInDecimal[h] = 4;
                    }
                    else if (((char)hexData[i + h]) == '5')
                    {
                        hexPairInDecimal[h] = 5;
                    }
                    else if (((char)hexData[i + h]) == '6')
                    {
                        hexPairInDecimal[h] = 6;
                    }
                    else if (((char)hexData[i + h]) == '7')
                    {
                        hexPairInDecimal[h] = 7;
                    }
                    else if (((char)hexData[i + h]) == '8')
                    {
                        hexPairInDecimal[h] = 8;
                    }
                    else if (((char)hexData[i + h]) == '9')
                    {
                        hexPairInDecimal[h] = 9;
                    }
                    else if (((char)hexData[i + h]) == 'A' || ((char)hexData[i + h]) == 'a')
                    {
                        hexPairInDecimal[h] = 10;
                    }
                    else if (((char)hexData[i + h]) == 'B' || ((char)hexData[i + h]) == 'b')
                    {
                        hexPairInDecimal[h] = 11;
                    }
                    else if (((char)hexData[i + h]) == 'C' || ((char)hexData[i + h]) == 'c')
                    {
                        hexPairInDecimal[h] = 12;
                    }
                    else if (((char)hexData[i + h]) == 'D' || ((char)hexData[i + h]) == 'd')
                    {
                        hexPairInDecimal[h] = 13;
                    }
                    else if (((char)hexData[i + h]) == 'E' || ((char)hexData[i + h]) == 'e')
                    {
                        hexPairInDecimal[h] = 14;
                    }
                    else if (((char)hexData[i + h]) == 'F' || ((char)hexData[i + h]) == 'f')
                    {
                        hexPairInDecimal[h] = 15;
                    }
                }
                // Join hex 4 bit(left hex cahr) + 4bit(right hex char) in bytes 8 it
                retVal.WriteByte((byte)((hexPairInDecimal[0] << 4) | hexPairInDecimal[1]));
            }
            return retVal.ToArray();
        }
        public static byte[] QuotedPrintableDecode(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            MemoryStream msRetVal = new MemoryStream();
            MemoryStream msSourceStream = new MemoryStream(data);
            int b = msSourceStream.ReadByte();
            while (b > -1)
            {
                // Encoded 8-bit byte(=XX) or soft line break(=CRLF)
                if (b == '=')
                {
                    byte[] buffer = new byte[2];
                    int nCount = msSourceStream.Read(buffer, 0, 2);
                    if (nCount == 2)
                    {
                        // Soft line break, line splitted, just skip CRLF
                        if (buffer[0] == '\r' && buffer[1] == '\n')
                        {
                        }
                        // This must be encoded 8-bit byte
                        else
                        {
                            try
                            {
                                msRetVal.Write(FromHex(buffer), 0, 1);
                            }
                            catch
                            {
                                // Illegal value after =, just leave it as is
                                msRetVal.WriteByte((byte)'=');
                                msRetVal.Write(buffer, 0, 2);
                            }
                        }
                    }
                    // Illegal =, just leave as it is
                    else
                    {
                        msRetVal.Write(buffer, 0, nCount);
                    }
                }
                // Just write back all other bytes
                else
                {
                    msRetVal.WriteByte((byte)b);
                }
                // Read next byte
                b = msSourceStream.ReadByte();
            }
            return msRetVal.ToArray();
        }
