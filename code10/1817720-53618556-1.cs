    string sourcePath = Dts.Variables["User::Source_Path"].Value.ToString();
    string destinationPath = Dts.Variables["User::Destination_Path"].Value.ToString();
    string line = string.Empty;
    string outputText = string.Empty;
    string headerText = "YourHeaderLine";
    string secondTextToOmit = "TextThatNeedsToBeOmitted";
    string thirdTextToOmit = "TextThatNeedsToBeOmitted";
    int headerCount = 0;
    try
    {
        using (StreamReader sr = new StreamReader(sourcePath))
        {
            while ((line = sr.ReadLine()) != null)
            {
                //only write first occurance
                if (line == headerText && headerCount == 0)
                {
                    outputText = outputText + line + Environment.NewLine;
                    headerCount++;
                }
                else
                 //store text in variables to do checks all in same if statement
                 //IndexOf looks for while space
                 if (line.IndexOf(' ') < 0 && line != headerText
                    && line != secondTextToOmit && line != thirdTextToOmit)
                {
                    outputText = outputText + line + Environment.NewLine;
                }
                //initialize StreamWriter using file path
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    //write the string using filtered text
                    writer.WriteLine(outputText);
                }
            }
        }
    }
