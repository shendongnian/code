    public class ConstTest
    {
        private const int ConstField = 123;
        public int GetValueOfConstViaReflection()
        {
            var fields = this.GetType().GetRuntimeFields();
            return (int)fields.First(f => f.Name == nameof(ConstField)).GetValue(null);
        }
    }
