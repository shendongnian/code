    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Text;
    using System.Threading;
    
    namespace ConvertNumbersInScientificNotationToPlainNumbers
    {
        class Program
        {
            private static string ToLongString(double input)
            {
                string str = input.ToString(System.Globalization.CultureInfo.InvariantCulture);
    
                // if string representation was collapsed from scientific notation, just return it:
                if (!str.Contains("E")) return str;
    
                var positive = true;
                if (input < 0)
                {
                    positive = false;
                }
    
                string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                char decSeparator = sep.ToCharArray()[0];
    
                string[] exponentParts = str.Split('E');
                string[] decimalParts = exponentParts[0].Split(decSeparator);
    
                // fix missing decimal point:
                if (decimalParts.Length == 1) decimalParts = new string[] { exponentParts[0], "0" };
    
                int exponentValue = int.Parse(exponentParts[1]);
    
                string newNumber = decimalParts[0].Replace("-", "").
                    Replace("+", "") + decimalParts[1];
    
                string result;
    
                if (exponentValue > 0)
                {
                    if (positive)
                        result =
                            newNumber +
                            GetZeros(exponentValue - decimalParts[1].Length);
                    else
    
                        result = "-" +
                         newNumber +
                         GetZeros(exponentValue - decimalParts[1].Length);
    
    
                }
                else // negative exponent
                {
                    if (positive)
                        result =
                            "0" +
                            decSeparator +
                            GetZeros(exponentValue + decimalParts[0].Replace("-", "").
                                       Replace("+", "").Length) + newNumber;
                    else
                        result =
                        "-0" +
                        decSeparator +
                        GetZeros(exponentValue + decimalParts[0].Replace("-", "").
                                 Replace("+", "").Length) + newNumber;
    
                    result = result.TrimEnd('0');
                }
                float temp = 0.00F;
    
                if (float.TryParse(result, out temp))
                {
                    return result;
                }
                throw new Exception();
            }
    
            private static string GetZeros(int zeroCount)
            {
                if (zeroCount < 0)
                    zeroCount = Math.Abs(zeroCount);
    
                StringBuilder sb = new StringBuilder();
    
                for (int i = 0; i < zeroCount; i++) sb.Append("0");
    
                return sb.ToString();
            }
    
            public static void Main(string[] args)
            {
                //Get Input Directory.
                Console.WriteLine(@"Enter the Input Directory");
                var readLine = Console.ReadLine();
                if (readLine == null)
                {
                    Console.WriteLine(@"Enter the input path properly.");
                    return;
                }
                var pathToInputDirectory = readLine.Trim();
    
                //Get Output Directory.
                Console.WriteLine(@"Enter the Output Directory");
                readLine = Console.ReadLine();
                if (readLine == null)
                {
                    Console.WriteLine(@"Enter the output path properly.");
                    return;
                }
                var pathToOutputDirectory = readLine.Trim();
    
                //Get Delimiter.
                Console.WriteLine("Enter the delimiter;");
                var columnDelimiter = (char)Console.Read();
    
                //Loop over all files in the directory.
                foreach (var inputFileName in Directory.GetFiles(pathToInputDirectory))
                {
                    var outputFileWithouthNumbersInScientificNotation = string.Empty;
                    Console.WriteLine("Started operation on File : " + inputFileName);
    
                    if (File.Exists(inputFileName))
                    {
                        // Read the file
                        using (var file = new StreamReader(inputFileName))
                        {
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                String[] columns = line.Split(columnDelimiter);
                                var duplicateLine = string.Empty;
                                int lengthOfColumns = columns.Length;
                                int counter = 1;
                                foreach (var column in columns)
                                {
                                    var columnDuplicate = column;
                                    try
                                    {
                                        if (Regex.IsMatch(columnDuplicate.Trim(),
                                                          @"^[+-]?[0-9]+(\.[0-9]+)?[E]([+-]?[0-9]+)$",
                                                          RegexOptions.IgnoreCase))
                                        {
                                            Console.WriteLine("Regular expression matched for this :" + column);
    
                                            columnDuplicate = ToLongString(Double.Parse
                                                                               (column,
                                                                                System.Globalization.NumberStyles.Float));
    
                                            Console.WriteLine("Converted this no in scientific notation " +
                                                              "" + column + "  to this number " +
                                                              columnDuplicate);
                                        }
                                    }
                                    catch (Exception)
                                    {
    
                                    }
                                    duplicateLine = duplicateLine + columnDuplicate;
    
                                    if (counter != lengthOfColumns)
                                    {
                                        duplicateLine = duplicateLine + columnDelimiter.ToString();
                                    }
                                    counter++;
                                }
                                duplicateLine = duplicateLine + Environment.NewLine;
                                outputFileWithouthNumbersInScientificNotation = outputFileWithouthNumbersInScientificNotation + duplicateLine;
                            }
    
                            file.Close();
                        }
    
                        var outputFilePathWithoutNumbersInScientificNotation
                            = Path.Combine(pathToOutputDirectory, Path.GetFileName(inputFileName));
    
                        //Create Directory If it does not exist.
                        if (!Directory.Exists(pathToOutputDirectory))
                            Directory.CreateDirectory(pathToOutputDirectory);
    
                        using (var outputFile =
                            new StreamWriter(outputFilePathWithoutNumbersInScientificNotation))
                        {
                            outputFile.Write(outputFileWithouthNumbersInScientificNotation);
                            outputFile.Close();
                        }
    
                        Console.WriteLine("The transformed file is here :" +
                            outputFilePathWithoutNumbersInScientificNotation);
                    }
                }
            }
        }
    }
