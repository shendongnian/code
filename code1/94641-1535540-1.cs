Requires reference to System.Web.Extensions assembly;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
class Program
{
    public class Test
    {
        public string Id { get; set; }
        public string Answer { get; set; }
    }
    static void Main(string[] args)
    {
        string data ="[[\"9\",\"3\"],[\"8\",\"4\"],[\"7\",\"4\"],[\"6\",\"5\"]]";
        List&lt;Test> tests = 
            Array.ConvertAll&lt;ArrayList, Test>(
                new JavaScriptSerializer()
                    .Deserialize&lt;ArrayList>(data)
                        .OfType&lt;ArrayList>().ToArray(), 
               (item) =>
               {
                   return new Test()
                   {
                       Id = (string)item[0],
                       Answer = (string) item[1]
                   };
               }).ToList();
    }
}
