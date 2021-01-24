    publiv void PerformDecode(string sourcePath, string targetPath)
    {
        File.WriteAllLines(targetPath,File.ReadLines(sourcePath).Select(line=>{
            short decodeCounter = 0;
            StringBuilder builder = new StringBuilder();
            foreach (var singleChar in line)
            {
                var positionInDecodeKey = decodingKeysList[decodeCounter].IndexOf(singleChar);
                if (positionInDecodeKey > 0)
                    builder.Append(model.Substring(positionInDecodeKey, 1));
                else
                    builder.Append(singleChar);
                if (decodeCounter > 18)
                    decodeCounter = 0;
                else ++decodeCounter;
            }
            return builder.ToString();
        }));
    }
