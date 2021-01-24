    byte[] arr = new byte[] { 11, 55, 255, 188, 99, 22, 31, 43, 25, 122 };
    
    string[] result = arr.Select(x => string.Join(",", Convert.ToString(x, 2)
                         .PadLeft(8, '0').ToCharArray())).ToArray();
    
    System.IO.File.WriteAllLines(@"D:\myFile.txt", result);
