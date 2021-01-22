    public void CheckType(Object param)
    {
       TypeA paramToCheck = param as TypeA;
       int count = 0;
       if (paramToCheck != null)
       {
           foreach (var paramB in listOfDifferentTypes)
           {
               var paramInList = paramB as TypeA;
               if (paramInList != null && paramToCheck.ID == paramInList.ID)
               {
                   count++;
                   if (count > 1)
                   {
                       paramToCheck.m_Error = "ErrorText";
                       break;
                   }
               }
           }
       }
