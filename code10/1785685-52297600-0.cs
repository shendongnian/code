    foreach (var inputLine in inputList)
            {
                if (inputLine.Contains(target))
                {
                    // Get everything in the line after the location of the target word
                    // (indexOf(target) + target.Length ensures we start at the end of the target word, rather than the beginning
                    var result = inputLine.Substring(inputLine.IndexOf(target) + target.Length);
                    var indexOfSeparator = result.IndexOf('>');
                    if (indexOfSeparator != -1)
                    {
                        // Grab everything from the start of the string to the location of the separator
                        result = result.Substring(0, indexOfSeparator);
                    }
                    Console.WriteLine(result);
                }
            }
