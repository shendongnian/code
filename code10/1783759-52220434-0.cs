    ushort x1 = 1;
    ushort x2 = 2;
    
    //get the bytes of the ushorts. 2 byte per number. 
    byte[] b1 = System.BitConverter.GetBytes(x1);
    byte[] b2 = System.BitConverter.GetBytes(x2);
    
    //Combine the two arrays to one array of length 4. 
    byte[] result = new Byte[4];
    result[0] = b1[0];
    result[1] = b1[1];
    result[2] = b2[0];
    result[3] = b2[1];
    
    //fill the bitArray.
    BitArray br = new BitArray(result);
    
    //test output.
    int c = 0;
    for (int i = br.Length -1; i >= 0; i--){
                    
        Console.Write(br.Get(i)? "1":"0");
        if (++c == 8)
        {
            Console.Write(" ");
            c = 0;
        }
    }
    
    //convert to int and output. 
    int[] array = new int[1];
    br.CopyTo(array, 0);
    Console.WriteLine();
    Console.Write(array[0]);
    
    Console.ReadLine();
