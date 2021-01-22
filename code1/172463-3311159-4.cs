    extern "C"
    {
    	#include "structs.h"
    }
    
    namespace Wrapper
    {
    	public __gc class NewStructB
    	{
    		private:
    			StructB b;
    
    		public:
    			NewStructB()
    			{
    			}
    
    			~NewStructB()
    			{
    			}
    
    			int getBMember1()
    			{
    				return b.bMember1;
    			}
    
    			void setBMember1(int value)
    			{
    				b.bMember1 = value;
    			}
    
    			int getBMember2()
    			{
    				return b.bMember2;
    			}
    
    			void setBMember2(int value)
    			{
    				b.bMember2 = value;
    			}
    
    			int* getBMember3()
    			{
    				return b.bMember3;
    			}
    
    			void setBMember3(int* value)
    			{
    				b.bMember3 = value;
    			}
    	};
    
    	public __gc class NewStructA
    	{
    		public:
    			NewStructB* b;
    
    			NewStructA()
    			{
    				b = new NewStructB();
    			}
    
    			~NewStructA()
    			{
    				delete b;
    			}
    
    			void ShowInfo()
    			{
    				System::Console::WriteLine(b->getBMember1().ToString());
    				System::Console::WriteLine(b->getBMember2().ToString());
    				System::Console::WriteLine((*b->getBMember3()).ToString());
    			}
    	};
    };
