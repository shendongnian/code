    .H-part:
    
    \#include < vcclr.h >
    
    \#using < MyCSharpModule.dll >
    
    using namespace System;
    
    class ATL_NO_VTABLE MyCSharpProxyServer :
    	public CComObjectRootEx< CComMultiThreadModel >,
    
    .....
    
    {
    
          HRESULT FinalConstruct();
    
          STDMETHODIMP LoadMyFile(BSTR FileName);
    .....
          gcroot<MyCSNamespace::MyCSharpClass^> m_CSClass;
    
    }
    
    .CPP-part:
    
    using namespace System::Collections;
    
    using namespace MyCSNamespace;
    
    HRESULT MyCSharpProxyServer::FinalConstruct()
    {
    
        m_CSClass = gcnew MyCSharpClass();
    
    }
    
    STDMETHODIMP MyCSharpProxyServer::LoadMyFile(BSTR FileName)
    {
    
        try {
           int hr = m_CSClass->LoadFile(gcnew String( FileName));
            return hr;
        }
        catch( Exception^ e )  {
            return E_FAIL;
        }
    }
