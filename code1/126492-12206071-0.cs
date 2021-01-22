    public class NullableBoolToLabel : ITypeConverter<bool?, string>
    {
        public string Convert(ResolutionContext context)
        {
            var source = (bool?)context.SourceValue;
            if (source.HasValue)
            {
                if (source.Value)
                    return "Yes";
                else
                    return "No";
            }
            else
                return "(n/a)";
        }
    }
