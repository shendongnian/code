    class Caller{
    
    	// see how it sends objects to method 'processAllClasses' with different classes
    	void main(){	
    	    ItemClass1 i1 = new ItemClass1();
    	    i1.setItemsB(1,2);
    	    processAllClasses(i1);
    
    	    ItemClass2 i2 = new ItemClass2();
    	    i2.setItemsB(10, 20);
    	    processAllClasses(i2);
    	}
    	
    	//using reflection and inherit to process different classes, obj is what need to be processed on.
    	//alternative way:
    	//get members from the type, then assign values to them one by one
    	void processAllClasses(ParentClass myobjvalue)
    	{ 
    	    Type realtype = myobjvalue.GetType();
    	    ParentClass myobj = new ParentClass(); 
    	    MethodInfo mi = realtype.GetMethod("setItemsA");
    	    object obj = Activator.CreateInstance(realtype);
    	    Object[] parameter = new Object[] { myobjvalue };
    	    mi.Invoke(obj, parameter); 
    	}
    }
    
    
    
    class ParentClass {
    
    }
    
    
    class ItemClass1: ParentClass
    {
        int ItemID;
        int ItemBaseID;
        public void setItemsA(ItemClass1 itemclass1)
        {
            this.ItemID = itemclass1.ItemID;
            this.ItemBaseID = itemclass1.ItemBaseID;
        }
        public void setItemsB(int ItemID, int ItemBaseID)
        {
            this.ItemID = ItemID;
            this.ItemBaseID = ItemBaseID;
        }
    
    }
    
    class ItemClass2 : ParentClass
    {
        int ContragentID;
        int ContragentTypeID;
        public void setItemsA(ItemClass2 itemclass2)
        {
            this.ContragentID = itemclass2.ContragentID;
            this.ContragentTypeID = itemclass2.ContragentTypeID;
        }
        public void setItemsB(int ContragentID, int ContragentTypeID)
        {
            this.ContragentID = ContragentID;
            this.ContragentTypeID = ContragentTypeID;
        }
    
    }
