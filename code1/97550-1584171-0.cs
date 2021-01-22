    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace Unknown.Tests
    {
    
        public static class MvcAssert
        {
    
            public static MemberInfo[] HasPostAction(Controller controller, string actionName, int expectedCount)
            {
                if (controller == null)
                    throw new ArgumentNullException("controller");
    
                if (string.IsNullOrEmpty(actionName))
                    throw new ArgumentNullException("actionName");
    
                MemberInfo[] members = controller.GetType().FindMembers(
                    MemberTypes.Method,
                    BindingFlags.Public | BindingFlags.Instance,
                    (m, c) => (m.Name == actionName && m.IsDefined(typeof(AcceptVerbsAttribute), false) && ((AcceptVerbsAttribute)Attribute.GetCustomAttribute(m, typeof(AcceptVerbsAttribute))).Verbs.Any((v) => v.Equals("Post", StringComparison.InvariantCultureIgnoreCase))),
                    null);
    
                Assert.AreEqual<int>(expectedCount, members.Length);
    
                return members;
            }
    
        }
    
    }
