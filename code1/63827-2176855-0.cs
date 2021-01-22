    using namespace System;
    
    namespace CPPLib 
    {
    	[System::Runtime::CompilerServices::Extension]
    	public ref class StringExtensions abstract sealed
    	{
    	public: 
    		[System::Runtime::CompilerServices::Extension]
    		static bool MyIsNullOrEmpty(String^ s)
    		{
    			return String::IsNullOrEmpty(s);
    		}
    	};
    }
