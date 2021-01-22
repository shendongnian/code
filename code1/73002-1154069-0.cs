       public class MyFieldCollection: Dictionary<string, Field>
       {
           public IEnumerable<XmlDataDocument> Data
           {
               foreach(Field f in this.Values)
                  yield return f.Data;
           }
       }
