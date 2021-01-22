    if(myInstance is MyBaseType)
    {
      MyBaseType myInstanceAsBaseType = myInstance as MyBaseType;
      // handle MyBaseType specific issue
    }
    else if(myInstance is MyOtherBaseType)
    {
      MyOtherBaseType myInstanceAsOtherBaseType = myInstance as MyOtherBaseType;
      // handle MyOtherBaseType specific issue.
    }
