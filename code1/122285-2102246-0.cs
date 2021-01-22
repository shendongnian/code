using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public static void RunSnippet()
{
   string s = "123";
   byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
   System.Collections.BitArray bArr = new System.Collections.BitArray(b);
   Console.WriteLine("bArr.Count = {0}", bArr.Count);
   for(int i = 0; i &lt; bArr.Count; i++)
	Console.WriteLin(string.Format("{0}", bArr.Get(i).ToString()));
   BinaryFormatter bf = new BinaryFormatter();
   using (FileStream fStream = new FileStream("test.bin", System.IO.FileMode.CreateNew)){
	bf.Serialize(fStream, (System.Collections.BitArray)bArr);
	Console.WriteLine("Serialized to test.bin");
   }
   Console.ReadLine();
}
