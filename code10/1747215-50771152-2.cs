    public class BsnValidationTriggerAction : TriggerAction<Entry>
    {
        private string _prevValue = string.Empty;
        protected override void Invoke(Entry entry)
        {
            decimal n;
            var isDecimal = decimal.TryParse(entry.Text, out n);
            
            _prevValue = isDecimal ? entry.Text : _prevValue; 
       }
    }
