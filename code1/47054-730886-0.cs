    Sat = 0.5 * 255 //assuming we want range 0-255...
    Brightness = 0.9 * 255
    NumberOfColours = 7
    HueSeparation = 360 / 7
    Colors = []
    for (i = 0 ; i< NumberOfColours; i++)
         Colors.Add(Color.FromHSV(HueSeparation * i, Sat, Brightness)
