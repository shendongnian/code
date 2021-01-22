    Color[] KnownColors; 
 
    void Init (){
        KnownColors = (from colorInfo in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.CreateInstance |BindingFlags.Public)
                       where colorInfo.PropertyType == typeof (Color)
                       select (Color)colorInfo.GetValue(null, null)).Where (c => c.A != 0).ToArray();
    }
    string GetColorName(Color inColour)
    {
        // I'm just getting started on LINQ so im not
        // sure how to do this with it (Maybe some one can help out with that)
        int MinDistance = int.MaxValue;
        Color closestKnown = Color.Black;
        foreach (var c in KnownColors)
        {
            var d = ColorDistance(c, inColour);
            if (d < MinDistance){
                closestKnown = c;
                MinDistance = d;
            }
        }
        return closestKnown.Name;
    }
   
    int ColorDistance(Color c1, Color c2)
        {
        var ad = (c1.A - c2.A);
        var rd = (c1.R - c2.R);
        var gd = (c1.G - c2.G);
        var bd = (c1.B - c2.B);
        return (ad * ad) + (rd * rd) + (gd * gd) + (bd * bd);
    }
