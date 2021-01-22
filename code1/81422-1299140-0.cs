    MyValues values = MyValues.adam;
    string[] forDatabinding = values.SpecialSort("someOptions");
    ...The extension method... 
    public static class Utils
        {
            public static string[] SpecialSort(this MyValues theEnum, string someOptions)
            {
                //sorting code here;
            }
        }
