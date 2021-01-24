    var bytes = new byte[] { 128, 255, 2 };
    var stringBuilder = new StringBuilder();
    for (var index = 0; index < bytes.Length; index++)
    {
    	var binary = Convert.ToString(bytes[index], 2).PadLeft(8, '0');
    	var str = string.Join(",", binary.ToCharArray());
    	stringBuilder.Append(str);
    	if (index != bytes.Length -1) stringBuilder.Append(",");
    }
    Console.WriteLine(stringBuilder);
