    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Web;
    using NUnit.Framework;
    using NUnit.Framework.SyntaxHelpers;
    
    [TestFixture]
    public class HttpContextCreation
    {
        [Test]
        public void TestCache()
        {
            var context = CreateHttpContext("index.aspx", "http://tempuri.org/index.aspx", null);
            var result = RunInstanceMethod(Thread.CurrentThread, "GetIllogicalCallContext", new object[] { });
            SetPrivateInstanceFieldValue(result, "m_HostContext", context);
    
            Assert.That(HttpContext.Current.Cache["val"], Is.Null);
    
            HttpContext.Current.Cache["val"] = "testValue";
            Assert.That(HttpContext.Current.Cache["val"], Is.EqualTo("testValue"));
        }
    
        private static HttpContext CreateHttpContext(string fileName, string url, string queryString)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var hres = new HttpResponse(sw);
            var hreq = new HttpRequest(fileName, url, queryString);
            var httpc = new HttpContext(hreq, hres);
            return httpc;
        }
    
        private static object RunInstanceMethod(object source, string method, object[] objParams)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var type = source.GetType();
            var m = type.GetMethod(method, flags);
            if (m == null)
            {
                throw new ArgumentException(string.Format("There is no method '{0}' for type '{1}'.", method, type));
            }
    
            var objRet = m.Invoke(source, objParams);
            return objRet;
        }
    
        public static void SetPrivateInstanceFieldValue(object source, string memberName, object value)
        {
            var field = source.GetType().GetField(memberName, BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ArgumentException(string.Format("Could not find the private instance field '{0}'", memberName));
            }
    
            field.SetValue(source, value);
        }
    }
