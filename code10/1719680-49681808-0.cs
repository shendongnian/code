    for (int i = 0; i < concentrationArray.Length; i++)
    {
        if (concentrationArray[i].Contains("Current"))
        {
             string[] result = concentrationArray[i].Split(new string[] { "(s): " }, StringSplitOptions.None);
             if(result.Length > 1)
                 lstTest.Items.Add(result[1]);
             else
                 Console.WriteLine("Line has no (s): followeed by a space");
        }
    }
