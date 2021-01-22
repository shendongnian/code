    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Things
    {
        public interface IThing
        {
    	    //define here properties that are shared between Thing & Other Thing
    	    public {type} Property1 { get; }
    	    public {type} Property2 { get; }
        }
    
        public class Thing : IThing
        {
    	    //this could even be an existing model - you just need to implement the interface on it as defined below.
    	    //define properties & methods only appropriate to this 
    
    	    Property1 { get {return what you need to here from your model }
    	    Property2 { get {return what you need to here from your model }
        }
    
        public class OtherThing : IThing
        {
    	    //this could also be an existing model - you just need to implement the interface on it as defined below.
    	    //define properties & methods only appropriate to this 
    
    	    Property1 { get {return what you need to here from your model }
    	    Property2 { get {return what you need to here from your model }
      
        }
    
        public class SomeThingViewModel
        {
          IThing _thing;
    
          public ThingViewModel
          {
              //you'll need something to get the "IThing" stored as a member.  You may want to take it in the constructor and force it to use it
              // or maybe you asign it throuhg a property - your situation should choose which!
              //If you REALLY need to you can detect the type (Thing or OtherThing) in your functions usign Typeof and cast
              //to that type to use functions & properties NOT found in the interface...
    
              Public ThingViewModel(IThing thing)
              {
                  _thing = thing;         
              }
     
    
           // here you would define any properties the view model needs to expose from the interfaced model.
           public Property1 
           {
                Get { return _thing.Property1; }
           }
    
           public Property2
           {
               Get { return _thing.Property2; }
           }
    
           public void FunctionToBeCalledOnSelectedIndexChanged()
           {
               //use _thing's properties here and do what you gotta do.
           }
        }
    }
