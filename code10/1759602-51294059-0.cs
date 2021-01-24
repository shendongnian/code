    //here is where you initialize your array. you may need to tweak the values to match your byte range (array)
    byte[] dataArray = new byte[9] { 0x93, 0x0E, 0x40, 0xF9, 0x53, 0x00, 0x00, 0xB5, 0xDE };
    //here is where you initialize the NEW array you want to write where your matching array lives
    byte[] newArray = new byte[9] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
    // Open the file to search in
    BinaryReader br = new BinaryReader(File.OpenRead("D:/Users/Joey/Desktop/prod"));
    for (int i = 0; i <= br.BaseStream.Length; i++)
    {
        // Search the file for the STARTING byte of my match
        if (br.BaseStream.ReadByte() == (byte)0xC0)
        {
            Console.WriteLine("Found the byte at offset " + i); //write to the console on which offset it has been found
            //now that you have the position of the matching range (array), write your new values:
            br.BaseStream.Write(newArray, i, 9);
            break; //exit the loop when finished                    
        }
    }
