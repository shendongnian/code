    public class EncodingPickerModel : UIPickerViewModel
    {
        private readonly Action<EncodingType> _onItemSelected;
    
        public EncodingPickerModel(Action<EncodingType> onItemSelected)
        {
            _onItemSelected = onItemSelected;
        }
    
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
    
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Enum.GetNames(typeof(EncodingType)).Length;
        }
    
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0) return row.ToString();
            return ((EncodingType)Convert.ToInt32(row)).ToString("F");
        }
    
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var encodingType = ((EncodingType)Convert.ToInt32(row)); 
    
            _onItemSelected.Invoke(encodingType);
           
        }
    }
    
    //usage:
    
    myPicker.Model = new EncodingPickerModel(OnEncodingTypeSelected)
    
    private void OnEncodingTypeSelected(EncodingType encType)
    {
        //do stuff like setting text property on label or textview, etc.
    }
