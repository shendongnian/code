    #include <windows.h>
    namespace JDanielSmith
    {
    	public ref class Utilities abstract sealed /* abstract sealed = static */
    	{
    	public:
    		CA_SUPPRESS_MESSAGE("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")
    		static void SetSystemTime(System::DateTime dateTime) {
    			LARGE_INTEGER largeInteger;
    			largeInteger.QuadPart = dateTime.ToFileTimeUtc(); // "If your compiler has built-in support for 64-bit integers, use the QuadPart member to store the 64-bit integer."
    
        
    			FILETIME fileTime; // "...copy the LowPart and HighPart members [of LARGE_INTEGER] into the FILETIME structure."
    			fileTime.dwHighDateTime = largeInteger.HighPart;
    			fileTime.dwLowDateTime = largeInteger.LowPart;
    
    
    			SYSTEMTIME systemTime;
    			if (FileTimeToSystemTime(&fileTime, &systemTime))
    			{
    				if (::SetSystemTime(&systemTime))
    					return;
    			}
    
    
    			HRESULT hr = HRESULT_FROM_WIN32(GetLastError());
    			throw System::Runtime::InteropServices::Marshal::GetExceptionForHR(hr);
    		}
    	};
    }
