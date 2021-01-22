    byte[] Take_Byte_Arr_From_Int(Int64 Source_Num)
    {
       Int64 Int64_Num = Source_Num;
       byte Byte_Num;
       byte[] Byte_Arr = new byte[8];
       for (int i = 0; i < 8; i++)
       {
          if (Source_Num > 255)
          {
             Int64_Num = Source_Num / 256;
             Byte_Num = (byte)(Source_Num - Int64_Num * 256);
          }
          else
          {
             Byte_Num = (byte)Int64_Num;
             Int64_Num = 0;
          }
          Byte_Arr[i] = Byte_Num;
          Source_Num = Int64_Num;
       }
       return (Byte_Arr);
    }
