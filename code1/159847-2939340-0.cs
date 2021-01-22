    StringBuilder stringBuilder = new StringBuilder();
    foreach (int value in obj.FindID(str1, str2))
    {
        stringBuilder.AppendLine(value.ToString());
    }
    // Call this once.
    Console.Write(stringBuilder.ToString());
