    using Newtonsoft.Json.Linq;
    internal class DymanicTest
    {
        public static string Json = @"{
    ""AED"": 3.672825,
    ""AFN"": 56.982875,
    ""ALL"": 110.252599,
    ""AMD"": 408.222002,
    ""ANG"": 1.78704,
    ""AOA"": 98.192249,
    ""ARS"": 8.44469
 }";
        public static void Run()
        {
            dynamic dynamicObject = JObject.Parse(Json);
            foreach (JProperty variable in dynamicObject)
            {
                if (variable.Name == "AMD")
                {
                    var value = variable.Value;
                }
            }
        }
    }
