        public class MaskedValueProvider : IValueProvider
        {
            public object GetValue(object target)
            {
                return "***";
            }
            public void SetValue(object target, object value)
            {
                throw new NotImplementedException();
            }
        }
