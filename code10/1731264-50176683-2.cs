    [assembly: ResolutionGroupName("Company")]
    [assembly: ExportEffect(typeof(CapitalizeKeyboardEffect), nameof(CapitalizeKeyboardEffect))]
    namespace VINEntryApp.iOS.Custom
    {
        [Preserve]
        public class CapitalizeKeyboardEffect : PlatformEffect
        {
            private UITextAutocapitalizationType _old;
    
            protected override void OnAttached()
            {
                var editText = Control as UITextField;
                if (editText != null)
                {
                    _old = editText.AutocapitalizationType;
                    editText.AutocapitalizationType = UITextAutocapitalizationType.AllCharacters;
                }
            }
    
            protected override void OnDetached()
            {
                var editText = Control as UITextField;
                if (editText != null)
                    editText.AutocapitalizationType = _old;
            }
        }
    }
