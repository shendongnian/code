        //pre-load the bits -- do this only ONCE
        byte[] baHi = new byte[16];
	    baHi[0]=0;
        baHi[1] = 000 + 00 + 00 + 16; //0001
        baHi[2] = 000 + 00 + 32 + 00; //0010
        baHi[3] = 000 + 00 + 32 + 16; //0011
        baHi[4] = 000 + 64 + 00 + 00; //0100
        baHi[5] = 000 + 64 + 00 + 16; //0101
        baHi[6] = 000 + 64 + 32 + 00; //0110
        baHi[7] = 000 + 64 + 32 + 16; //0111
        baHi[8] = 128 + 00 + 00 + 00; //1000
        baHi[9] = 128 + 00 + 00 + 16; //1001
        //not needed for 0-9
        //baHi[10] = 128 + 00 + 32 + 00; //1010
        //baHi[11] = 128 + 00 + 32 + 16; //1011
        //baHi[12] = 128 + 64 + 00 + 00; //1100
        //baHi[13] = 128 + 64 + 00 + 16; //1101
        //baHi[14] = 128 + 64 + 32 + 00; //1110
        //baHi[15] = 128 + 64 + 32 + 16; //1111
        //-------------------------------------------------------------------------
        //START PACKING
        //load TWO digits (0-9) at a time
        //this means if you're loading a big number from
        //a file, you read two digits at a time
        //and put them into bLoVal and bHiVal
        //230942034371231235  see that '37' in the middle?
        //         ^^
        //
        
        byte bHiVal = 3; //0000 0011 
        byte bLoVal = 7; //0000 1011 
        byte bShiftedLeftHiVal = (byte)baHi[bHiVal]; //0011 0000  =3, shifted (48)    
        //fuse the two together into a single byte
        byte bNewVal = (byte)(bShiftedLeftHiVal + bLoVal); //0011 1011 = 55 decimal
        //now store bNewVal wherever you want to store it
        //for later retrieval, like a byte array
        //END PACKING
        //-------------------------------------------------------------------------
        
        
        Response.Write("PACKING: hi: " + bHiVal + " lo: " + bLoVal + " packed: " + bNewVal);
        Response.Write("<br>");
        //-------------------------------------------------------------------------
        //START UNPACKING
        byte bUnpackedLoByte = (byte)(bNewVal & 15);  //will yield 7
        byte bUnpackedHiByte = (byte)(bNewVal & 240); //will yield 48
        //now we need to change '48' back into '3'
        string sHiBits = "00000000" + Convert.ToString(bUnpackedHiByte, 2); //drops leading 0s, so we pad...
        sHiBits = sHiBits.Substring(sHiBits.Length - 8, 8);                 //and get the last 8 characters
        sHiBits = ("0000" + sHiBits).Substring(0, 8);                       //shift right
        bUnpackedHiByte = (byte)Convert.ToSByte(sHiBits, 2);                //and, finally, get back the original byte
        //the above method, reworked, could also be used to PACK the data,
        //though it might be slower than hitting an array.
        //You can also loop through baHi to unpack, comparing the original
        //bUnpackedHyByte to the contents of the array and return
        //the index of where you found it (the index would be the 
        //unpacked digit)
        Response.Write("UNPACKING: input: " + bNewVal + " hi: " + bUnpackedHiByte + " lo: " + bUnpackedLoByte);
        
        //now create your output with bUnpackedHiByte and bUnpackedLoByte,
        //then move on to the next two bytes in where ever you stored the
        //really big number
        //END UNPACKING
        //-------------------------------------------------------------------------
