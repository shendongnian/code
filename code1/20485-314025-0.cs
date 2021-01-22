    myProperties.Add(new CustomProperty("Custom", "", typeof(States), false, true));
    
    [TypeConverter(typeof(StatesList))]
    public class States
    {
    }
