    interface IThreeDimensional
    {
        double Thickness {get; set;}
        double Width {get; set;}
        double Length {get; set;}
    }
    static double GetVolume(this IThreeDimensional value)
    {
        return value.Thickness * value.Width * value.Length;
    }
