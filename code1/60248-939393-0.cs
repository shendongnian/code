    // 12-34-AB
    writer.Write(BitConverter.ToString(data));
    // 1234AB
    writer.Write(BitConverter.ToString(data).Replace("-", string.Empty));
    // 0x1234AB
    writer.Write("0x" + BitConverter.ToString(data).Replace("-", string.Empty));
    // [ 12, 34, AB ]
    writer.Write("[ " + BitConverter.ToString(data).Replace("-", ", ") + " ]");
    // [ 0x12, 0x34, 0xAB ]
    writer.Write("[ 0x" + BitConverter.ToString(data).Replace("-", ", 0x") + " ]");
