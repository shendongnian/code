    // TestCPlusPlus.h
    
    #pragma once
    
    using namespace System;
    using namespace DotNetLib;
    
    namespace TestCPlusPlus {
    
    	public ref class ManagedCPlusPlus
    	{
    	public:
    		int Add(int a, int b)
    		{
    			Calc^ c = gcnew Calc();
    			int result = c->Add(a, b);
    			return result;
    		}
    	};
    }
