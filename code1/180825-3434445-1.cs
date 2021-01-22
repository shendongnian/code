    public class TimeOfDayBinding
        : MarkupExtension
    {
        public PropertyPath Path { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding()
            {
                Path = Path,
                Converter = new TimeOfDayConverter(),
            };
            binding.ValidationRules.Add(new ValidateTimeOfDay()
            {
                ValidatesOnTargetUpdated = true,
            });
            return binding.ProvideValue(serviceProvider);
        }
    }
