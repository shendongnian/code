    using System.Runtime.Serialization;
    partial class MyWebService
    {
         [OnDeserialized]
         public void OnDeserialized(StreamingContext context)
         {
             // your code here
         }
    }
 
