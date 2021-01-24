    abstract class AbstractClass
    {
        public abstract void Process();
        // The "Template method"
        public void TemplateMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                //Create connection with database.
                Process();
                //Save results of those processing
            }
        //Step2:
        // Creating versioning here  : If this failed then rollback step1
        //Step3 : if step1 and step2 successfull than mark this job as succeeded else failed
        // Updating time of whole process in table
        }
    }
    class Type1 : AbstractClass
    {
        public override void Process()
        {
           //Do some processing based on type1
        } 
    }
    class Type2 : AbstractClass
    {
        public override void Process()
        {
            //Do some processing based on type2
        }
    }  
