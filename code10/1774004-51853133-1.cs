    //float[] timeValues;
    List<float> timeValues = new List<float>();
    float time;
    while (lineBeingRead != null)
    {
        valueSplit = lineBeingRead.Split(exerciseDivider);
        for (int i = 0; i < valueSplit.Length; i++)
        {
            if (valueSplit[i].Contains(textToFind))
            {
                exerciseLine = valueSplit[i];
                string[] timeValuesString = exerciseLine.Split(timeDivider);
                for (int a = 0; a < timeValuesString.Length; i++)
                {
                    time = float.Parse(timeValuesString[1]);
                    //timeValues = time;
                    timeValues.add(time);
                }
            }
        }
    }
