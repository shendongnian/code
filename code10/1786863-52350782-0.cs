    public class ObjectMapper
    {
        public void MapObject(object source, object destination)
        {
            var srcType = source.GetType();//get source type
            var srcProps = srcType.GetProperties();//get src props, supply appropriate binding flags
            var destType = destination.GetType();//get dest type
            var destProps = destType.GetProperties();//get dest props, supply appropriate binding flags
            foreach (var prop in srcProps)
            {
                //find corresponding prop on dest obj
                var destProp = destProps.FirstOrDefault(p => p.Name == prop.Name);
                //only map if found on dest obj
                if (destProp != null)
                {
                    //get src value
                    var srcVal = prop.GetValue(source);
                    //get src prop type
                    var propType = prop.PropertyType;
                    //get dest prop type
                    var destPropType = destProp.PropertyType;
                    //special case for collections
                    if (typeof(IList).IsAssignableFrom(propType))
                    {
                        //instantiate dest collection
                        var newCollection = (IList)Activator.CreateInstance(destPropType);
                        //get source collection
                        var collection = (IList)srcVal;
                        //get dest collection element type
                        var elementType = destPropType.GetGenericArguments().FirstOrDefault();
                        //iterate collection
                        foreach (var element in collection)
                        {
                            //instantiate element type 
                            var tempElement = Activator.CreateInstance(elementType);
                            //call map object on each element
                            MapObject(source: element, destination: tempElement);
                            //add mapped object to new collection
                            newCollection.Add(tempElement);
                        }
                        //set dest object prop to collection
                        destProp.SetValue(destination, newCollection);
                    }
                    else
                    {
                        destProp.SetValue(destination, srcVal);
                    }
                }
            }
        }
    }
