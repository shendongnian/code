    public void CheckType(Object param)
    {
       TypeA paramToCheck = param as TypeA;
       if (paramToCheck != null)
       {
           foreach (var paramB in listOfDifferentTypes)
           {
               var paramInList = paramB as TypeA;
               if (paramInList != null && paramToCheck.ID == paramInList.ID)
               {
                   paramToCheck.m_Error = "ErrorText";
                   break;
               }
           }
       }
