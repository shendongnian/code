    public class DirtyData
    {
        string Name {get; set;}
    }
    public class CleanData
    {
        private CleanData() {}
        string Name {get; set;}
        public static CleanData Validate(DirtyData d)
        {
            CleanData data = new CleanData();
            if (ValidateString(d.Name))
            { 
                 data.Name = d.Name
            }
            else
            {
                 throw new ValidationException();
            }
            return CleanData;
        }
    }
    //...
    public void DoSomething(CleanData data)
    {
        //...
    }
