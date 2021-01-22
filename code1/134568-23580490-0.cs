    public static class SqlCommandExtensions
    {
        public static void AddParametersWithValues<T>(this SqlCommand cmd,  string parameterName, params T[] values)
        {
            var parameterNames = new List<string>();
            for(int i = 0; i < values.Count(); i++)
            {
                var paramName = @"@param" + i;
                cmd.Parameters.AddWithValue(paramName, values.ElementAt(i));
                parameterNames.Add(paramName);
            }
    
            cmd.CommandText = cmd.CommandText.Replace(parameterName, string.Join(",", parameterNames));
        }
    }
