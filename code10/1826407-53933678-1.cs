    public static class ParametersExtensions
    {
        public static string GetValue(this List<Parameters> ListParameters, string searchedValue)
        {   
            var parameter = ListParameters.FirstOrDefault(x => x.Value .Equals(searchedValue)); 
            return parameter?.Value;
        }
    }
