    namespace Views
    {
    	public class RecordView 
    	{
    		private RecordDataFieldList<string, string> _fieldUnit
    		
    		private void Update()
    		{
    			_fieldNumericUnit.List = new IdValueList<string, string>
    			{            
    				new ListItem<string>((int)RecordVM.Enum.Minutes, RecordVM.Enum.Minutes.Name()),
    				new ListItem<string>((int)RecordVM.Enum.Hours, RecordVM.Enum.Hours.Name())
    			};
    
    			RecordVM.Enum eId = DetermineUnit();
    			
    			_fieldUnit.Input.Text = _fieldUnit.List[(int)eId].Value;
    			_fieldUnit.List.SetSelected((int)eId);
    		}
    	}
    }
