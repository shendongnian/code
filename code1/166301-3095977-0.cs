public static void Main()
{
    // Open a file that contains a public key value. The line below  
    // assumes that the Strong Name tool (SN.exe) was executed from 
    // a command prompt as follows:
    //       SN.exe -k C:\Company.keys
    FileStream fs = File.Open("C:\\Company.keys", FileMode.Open);
    // Construct a StrongNameKeyPair object. This object should obtain
    // the public key from the Company.keys file.
    StrongNameKeyPair k = new StrongNameKeyPair(fs);
    // Display the bytes that make up the public key.
    Console.WriteLine(BitConverter.ToString(k.PublicKey));
    // Close the file.
    fs.Close();
}
