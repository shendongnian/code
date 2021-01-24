c#
using System;
using System.Collections.Generic;
namespace CentralFramework.ScenarioContext
{
    public class ContextEntries
    {
        public Dictionary<string, object> contextCollection = new Dictionary<string, object>();
    }
}
Then in any class that I want to use it in I add the following:
c#
public class ScenarioHooks //An example class 
{
    ContextEntries context;
    public ScenarioHooks(ContextEntries context) //Newing up an instance in the constructor
    {
        this.context = context;
    }
To store something in the context it is very much like the original answer:
c#
context.contextCollection.Add("webDriver", webDriver);//Adding the webdriver to the collection, It could be anything.
To retrieve something from the collection:
c#
IWebDriver webDriver = (IWebDriver)context.contextCollection["webDriver"]; 
Just like with the Scenario Context you need to make sure you set the type when retrieving with the () since it is just stored as an object (string), (int), etc...
To remove something from the collection:
c#
context.contextCollection.Remove("webDriver");
All of the above examples are just how you deal with a dictionary. There is nothing special there. This solution works well. It has all of the validation that comes with a standard dictionary also which is nice.
