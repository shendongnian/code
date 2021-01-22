    public static T GetValueFromAnonymousType<T>( object dataitem, string itemkey ) {
                System.Type type = dataitem.GetType();
                T itemvalue = (T)type.GetProperty(itemkey).GetValue(dataitem, null);
                return itemvalue;
            }
