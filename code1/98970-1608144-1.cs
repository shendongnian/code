        static readonly object lockObj = new object();
        private static List<myObject> _myObject;
    
         public List<myObject> FillMyObject()
         {
             lock (lockObj)
             {
                if(_myObject == null || myTimer)
                   _myObject = getfromDataBase();
             }
         }
  
         public List<myObject> UpdateMyObject(somevalue)
         {
            lock (lockObj)
             {
                _myObject.RemoveAll(delegate(myObject o)
                                    {
                                        return o.somevalue == somevalue;
                                     });)
             }
         }
