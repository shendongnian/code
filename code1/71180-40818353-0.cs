    public class CustomTransformer : IResultTransformer
        {
            public System.Collections.IList TransformList(System.Collections.IList collection)
            {
                return collection;
            }
    
            public object TransformTuple(object[] tuple, string[] aliases)
            {
                return new MyDto
                {
                    //map your data to dto and convert to data type if needed
                    YourProperty1 = tuple[0],
                    YourProperty12 = (int)tuple[1]
                };
            }
        }
