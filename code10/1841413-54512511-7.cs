        private readonly IVersionInterface _versionCreator;
        protected AbstractClass(IVersionInterface versionCreator)
        {
            _versionCreator = versionCreator;
        }
        public abstract void Process();
        public void TemplateMethod()
        {
            var versionCreated = _versionCreator.CreateVersion();
            if (!versionCreated)
            {
              return;
            }
    
           for (int i = 0; i < 5; i++)
           {
               //Create connection with database.
               Process();
              //Save results of those processing
          }
          //Step3 : if step1 and step2 successful than mark this job as 
         //succeeded else failed
         // Updating time of whole process in table
        }
    }
    class Type1 : AbstractClass
    {
    
        public Type1(IVersionInterface versionCreator) : 
    base(versionCreator)
        {
        }
    
        public override void Process()
        {
            //Do some processing based on type1
        }
    }
    class Type2 : AbstractClass
    {
    
        public Type2(IVersionInterface versionCreator) : 
    base(versionCreator)
        {
        }
    
        public override void Process()
        {
            //Do some processing based on type2
        }
    }  
    interface IVersionInterface
    {
        bool CreateVersion();
    }
    class VersionCreator : IVersionInterface
    {
        //return true or false for success or failure
        public bool CreateVersion()
        {
            //logic here
        }
    }
