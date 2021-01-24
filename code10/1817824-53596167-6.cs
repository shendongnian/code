    string fileName2 = @"D:\UNI\Year 5\AI - SET09122\SET09122 - CW1\WriteConnectionData.txt";
    using (var sw = new StreamWriter(fileName2, true))
    {
        for (int z = 0; z <= totalNumberOfCaves; z++)
        {
            string delimiter = "";
            for (int i = 0; i < totalNumberOfCaves && connectionStack.Count > 0; i++)
            {
                sw.Write(delimiter);
                sw.Write(connectionStack.Pop());
                delimiter = ",";
            }
            sw.Write(Environment.NewLine);
        }
    }
