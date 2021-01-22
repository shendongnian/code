       void AsynchronousCall1()
       {
            // do some work
            Done("1");
       }
       void AsynchronousCall2()
       {
            // do some work
            Done("2");
       }
       object _exclusiveAccess = new object();
       bool _alreadyDone = false;
       void Done(string who)
       {
            lock (_exclusiveAccess)
            {
                 if (_alreadyDone)
                     return;
                 _alreadyDone = true;
                 Console.WriteLine(who + " was here first");
            }
       }
