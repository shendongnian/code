    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace MvcApplication4.Tests
    {
    
        public static class MvcAssert
        {
    
            public static MethodInfo ActionExists(Controller controller, string actionName, HttpVerbs expectedVerbs, params Type[] paramTypes)
            {
                if (controller == null)
                    throw new ArgumentNullException("controller");
    
                if (string.IsNullOrEmpty(actionName))
                    throw new ArgumentNullException("actionName");
    
                int actualVerbs = 0;
    
                MethodInfo action = controller.GetType().GetMethod(actionName, paramTypes);
                Assert.IsNotNull(action, string.Format("The specified action '{0}' could not be found.", actionName));
    
                AcceptVerbsAttribute acceptVerb = Attribute.GetCustomAttribute(action, typeof(AcceptVerbsAttribute)) as AcceptVerbsAttribute;
    
                if (acceptVerb == null)
                    actualVerbs = (int)HttpVerbs.Get;
                else
                    actualVerbs = (int)Enum.Parse(typeof(HttpVerbs), string.Join(", ", acceptVerb.Verbs.ToArray()), true);
    
                Assert.AreEqual<int>(actualVerbs, (int)expectedVerbs);
    
                return action;
            }
    
        }
    
    }
