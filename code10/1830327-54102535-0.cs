	// C# side: wrap your Dictionary<string, float> into a class implementing this interface.
	// lock() in the implementation if C++ retains the interface and calls it from other threads.
	[Guid( "..." ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
	interface iMyDictionary
	{
		void getValue( string key, out float value );
		void setValue( string key, float value );
	}
	[DllImport("my.dll")]
	extern static void useMyDictionary( iMyDictionary dict );
	// C++ side of the interop.
	__interface __declspec( uuid( "..." ) ) iMyDictionary: public IUnknown
	{
		HRESULT __stdcall getValue( const wchar_t *key, float& value );
		HRESULT __stdcall setValue( const wchar_t *key, float value );
	};
	extern "C" __declspec( dllexport ) HRESULT __stdcall useMyDictionary( iMyDictionary* dict );
