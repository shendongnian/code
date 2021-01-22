     using System.Linq; //SequenceEqual
     
     byte[] ByteArray1 = null;
     byte[] ByteArray2 = null;
     
     ByteArray1 = MyFunct1();
     ByteArray2 = MyFunct2();
     
     if (ByteArray1.SequenceEqual<byte>(ByteArray2) == true)
     {
        MessageBox.Show("Match");
     }
     else
     {
       MessageBox.Show("Don't match");
     }
