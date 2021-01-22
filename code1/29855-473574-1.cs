            BinaryFormatter bf = new BinaryFormatter();
            byte[] bytes;
            MemoryStream ms = new MemoryStream();
            string orig = "你好 Hello 谢谢 Thank You";
            bf.Serialize(ms, orig);
            ms.Seek(0, 0);
            bytes = ms.ToArray();
            MessageBox.Show("Original Length: " + orig.Length.ToString());
            for (int i = 0; i < bytes.Length; ++i) bytes[i] ^= 88; // pseudo encrypt
            for (int i = 0; i < bytes.Length; ++i) bytes[i] ^= 88; // pseudo decrypt
            BinaryFormatter bfx = new BinaryFormatter();
            MemoryStream msx = new MemoryStream();            
            msx.Write(bytes, 0, bytes.Length);
            msx.Seek(0, 0);
            string sx = (string)bfx.Deserialize(msx);
            MessageBox.Show("Still intact :" + sx);
            MessageBox.Show("Deserialize Length(still intact): " + orig.Length.ToString());
