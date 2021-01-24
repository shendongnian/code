    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stackOverFlowAnswer
    {
        class Program
        {
            // a collection to store all objects
            static ArrayList allObjects = new ArrayList();
            static void Main(string[] args)
            {
                // Call the object creation function whenever you want
                for (int i = 0; i < 5; i++)
                {
                    createANewObject();
                }
            }
    
            // function that create an object at a time
            static void createANewObject()
            {
                YourObject newObject = new YourObject();
                allObjects.Add(newObject);
            }
        }
    
        // your object class
        class YourObject
        {
    
        }
    }
