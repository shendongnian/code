     public static bool IsValidDicom(BinaryReader r)
        {
            try
            {
                //128 null bytes
                byte[] nullBytes = new byte[128];
                r.Read(nullBytes, 0, 128);
                foreach (byte b in nullBytes)
                {
                    if (b != 0x00)
                    {
                        //Not valid
                        Console.WriteLine("Missing 128 null bit preamble. Not a valid DICOM file!");
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read 128 null bit preamble. Perhaps file is too short");
                return false;
            }
            try
            {
                //4 DICM characters
                char[] dicm = new char[4];
                r.Read(dicm, 0, 4);
                if (dicm[0] != 'D' || dicm[1] != 'I' || dicm[2] != 'C' || dicm[3] != 'M')
                {
                    //Not valid
                    Console.WriteLine("Missing characters D I C M in bits 128-131. Not a valid DICOM file!");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read DICM letters in bits 128-131.");
                return false;
            }
        }
