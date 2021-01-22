    public static class FormExtensions
    {
        public static IList<T> GetControlsOf<T>(this Form form) where T: class
        {
            var result = new List<T>();
            foreach (var control in form.Controls)
            {
                if ((control as T) != null)
                    result.Add(control as T);
            }
            return result;
        }
    }
