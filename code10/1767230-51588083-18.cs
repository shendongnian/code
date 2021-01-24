    catch (Exception ex)
    {
        //You may check any particular exception and write your code
        if (ex.GetType() == typeof(ArgumentNullException))
        {
            //Do code here 
        }
        else
        if (ex.GetType() == typeof(WebException))
        {
            //Do code here 
        }
        else
        if (ex.GetType() == typeof(NotSupportedException))
        {
            //Do code here 
        }
    
     }
