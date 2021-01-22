    namespace Views
    {
    	public class RecordView 
    	{
    		private RecordDataFieldList<string, string> _fieldUnit
    		
    		private void Update()
    		{
    			_fieldUnit.List = new IdValueList<string, string>
    			{            
    				new ListItem<string>((int)RecordVM.Enum.Minutes, RecordVM.Enum.Minutes.Name()),
    				new ListItem<string>((int)RecordVM.Enum.Hours, RecordVM.Enum.Hours.Name())
    			};
    
    			RecordVM.Enum eId = DetermineUnit();
    			
    			//_fieldUnit.List.SetSelected((int)eId);
                //_fieldUnit.Input.Text = _fieldUnit.List.SelectedItem.Value;
                _fieldUnit.Input.Text = _fieldUnit.List.SetSelected((int)eId).Value;
    		}
    	}
    }
