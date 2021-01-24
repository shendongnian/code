    [assembly: ResolutionGroupName("Company")]
    [assembly: ExportEffect(typeof(CapitalizeKeyboardEffect), nameof(CapitalizeKeyboardEffect))]
    namespace VINEntryApp.Droid.Custom
    {
        [Preserve]
        public class CapitalizeKeyboardEffect : PlatformEffect
        {
            private InputTypes _old;
            private IInputFilter[] _oldFilters;
    
            protected override void OnAttached()
            {
                var editText = Control as EditText;
                if (editText != null)
                {
                    _old = editText.InputType;
                    _oldFilters = editText.GetFilters().ToArray();
    
                    editText.SetRawInputType(InputTypes.ClassText | InputTypes.TextFlagCapCharacters);
    
                    var newFilters = _oldFilters.ToList();
                    newFilters.Add(new InputFilterAllCaps());
                    editText.SetFilters(newFilters.ToArray());
                }
            }
    
            protected override void OnDetached()
            {
                var editText = Control as EditText;
                if (editText != null)
                {
                    editText.SetRawInputType(_old);
                    editText.SetFilters(_oldFilters);
                }
            }
        }
    }
