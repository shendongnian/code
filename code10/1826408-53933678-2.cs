    public static class ParametersExtensions
    {
        public static void SetValue(this List<Parameters> ListParameters, string name, string newValue)
        {   
            var parameter = ListParameters.FirstOrDefault(x => x.Name.Equals(name)); 
            if (parameter != null)
                parameter.Value = newValue;
        }
    }
