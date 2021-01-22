    byte[] myByteArray = new byte[holder.Length];
    int i = 0;
    foreach (string item in holder)
    {
        myByteArray[i++] = byte.Parse(item, System.Globalization.NumberStyles.AllowHexSpecifier); 
    }
