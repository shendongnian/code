    BinaryFormatter bf = new BinaryFormatter();
    byte[] bytes;
    MemoryStream ms = new MemoryStream();
    string orig = "喂 Hello 谢谢 Thank You";
    bf.Serialize(ms, orig);
    ms.Seek(0, 0);
    bytes = ms.ToArray();
    MessageBox.Show("Original bytes Length: " + bytes.Length.ToString());
    MessageBox.Show("Original string Length: " + orig.Length.ToString());
    for (int i = 0; i < bytes.Length; ++i) bytes[i] ^= 65; // pseudo encrypt
    for (int i = 0; i < bytes.Length; ++i) bytes[i] ^= 65; // pseudo decrypt
    BinaryFormatter bfx = new BinaryFormatter();
    MemoryStream msx = new MemoryStream();            
    msx.Seek(0, 0);
    msx.Write(bytes, 0, bytes.Length);
    msx.Seek(0, 0);
    string sx = (string)bfx.Deserialize(msx);
    MessageBox.Show("Still intact :" + sx);
   
    MessageBox.Show("Deserialize string Length(still intact): " + orig.Length.ToString());
    BinaryFormatter bfy = new BinaryFormatter();
    MemoryStream msy = new MemoryStream();
    bfy.Serialize(msy, sx);
    msy.Seek(0, 0);
    byte[] bytesy = msy.ToArray();
    MessageBox.Show("Deserialize bytes Length(still intact): " + bytesy.Length.ToString());
    
