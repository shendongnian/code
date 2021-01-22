     void MyMethod(PublishMode? mode)
        {
           var publishMode = mode ?? PublishMode.Edit;
           
    //or
           if (mode?? PublishMode.Edit == someValue)
           ....
        }
