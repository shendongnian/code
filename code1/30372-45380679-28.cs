    //namespace Common
    namespace ViewModels
    {
    	public static class EnumExtensions
        {
            public static string Name(this RecordVM.Enum id)
            {
                //return RecordVM.Enum.Name[(int)id];
                switch (id)
                {
                    case RecordVM.Enum.Minutes: return "Minute(s)";                    
                    case RecordVM.Enum.Hours: return "Hour(s)";
                    default: return null;
                }
            }
        }	
    }
