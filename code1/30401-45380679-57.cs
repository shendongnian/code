    namespace Common
    {
    	public static class EnumExtensions
        {
            public static string Name(this RecordVM.Enum.Id id)
            {
                return RecordVM.Enum.Name[(int)id];
            }
        }	
    }
