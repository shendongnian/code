    using System.IO;
    byte[] bytesFromFile = File.ReadAllBytes(filePath);
    byte[] someBytes = new byte[someLength];
    // omitted: put some values into someBytes array
    File.WriteAllBytes(filePath, someBytes);
