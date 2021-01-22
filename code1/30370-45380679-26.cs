    namespace Views
    {
    	public class RecordView 
    	{
    		private RecordDataFieldList<string, string> _fieldUnit
    		
    		private void Update()
    		{
    			_fieldNumericUnit.List = new IdValueList<string, string>
    			{            
    				new ListItem<string>((int)RecordVM.Enum.Id.Minutes, RecordVM.Enum.Id.Minutes.Name()),
    				new ListItem<string>((int)RecordVM.Enum.Id.Hours, RecordVM.Enum.Id.Hours.Name())
    			};
    
    			RecordVM.Enum.Id eId = DetermineUnit();
    			
    			_fieldUnit.List.SetSelected((int)eId);
                _fieldUnit.Input.Text = _fieldUnit.List.SelectedItem.Value;
                //_fieldUnit.Input.Text = _fieldUnit.List[(int)eId].Value;
    		}
    	}
    }
