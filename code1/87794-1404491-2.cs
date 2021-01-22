    #include "stdafx.h"
    
    using namespace System;
    using namespace System::Runtime::CompilerServices;
    
    namespace Blixt
    {
    namespace Utilities
    {
    	[Extension]
    	public ref class EnumUtility abstract sealed
    	{
    	public:
    		generic <typename T> where T : value class, Enum
    		[Extension]
    		static bool HasFlags(T value, T flags)
    		{
    			__int64 mask = Convert::ToInt64(flags);
    			return (Convert::ToInt64(value) & mask) == mask;
    		}
    	};
    }
    }
