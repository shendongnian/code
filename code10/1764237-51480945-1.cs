    double[] test = ParseLines(newPath).ToArray()
    foreach(double number in test)
    {
        Console.WriteLine(number);
    }         
    Console.ReadLine();
<!-->
    private static IEnumerable<double> ParseLines(string filePath)
    {  
        if(File.Exists(newPath))
        {
            foreach(string line in File.ReadLines(newPath))
            {
                double output;
                if(double.TryParse(line, out output))
                {
                    yield return output;
                }
            }
        }
    }
