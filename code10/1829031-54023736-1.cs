    public static string DisplayEmptyCircles(List<string> listLevel)
    {
        char[] emptyCircle = new char[listLevel.Count];
        for (int counterCircles = 0; counterCircles < listLevel.Count; counterCircles++)
        {
            emptyCircle[counterCircles] = Convert.ToChar(9675);             
        }
        return new string(emptyCircle);
    }
