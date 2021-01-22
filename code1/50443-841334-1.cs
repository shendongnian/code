    public static class FormExtensions
    {
        public static IDictionary<string, T> GetControlsOf<T>(this Form form) 
               where T: class
        {
            var result = new Dictionary<string, T>();
            foreach (var control in form.Controls)
            {
                if ((control as T) != null)
                    result.Add((control as T).Tag, control as T);
            }
            return result;
        }
    }
