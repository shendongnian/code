        var input =
            "[{\"CombinationCode\":127,\"Pattern\":\"4545,.86,4520,.44,4592\"},{\"CombinationCode\":128,\"Pattern\":\"4545,.86,4520,.44,4592\"},{\"CombinationCode\":129,\"Pattern\":\"4545,.86,4520,.44,4592\"}]";
        var arr = JsonConvert.DeserializeObject<List<JToken>>(input);
        const int emptyArraySquareBracesCount = 2;
        const int charsBetweenElements = 1;
        
        var maxSize = 165;
        var buffer = new JArray();
        var bufferLength = emptyArraySquareBracesCount;
        var elementsInChunk = 0;
        
        foreach (var element in arr)
        {
            var part = element.ToString(Formatting.None);
            if (bufferLength + part.Length > maxSize)
            {
                Console.WriteLine(buffer.ToString(Formatting.None));
                buffer = new JArray();
                elementsInChunk = 0;
                bufferLength = emptyArraySquareBracesCount + part.Length;
                buffer.Add(element);
            }
            else
            {
                elementsInChunk++;
                bufferLength += charsBetweenElements + part.Length;
                buffer.Add(element);
            }
        }
        
        Console.WriteLine(buffer.ToString(Formatting.None));
