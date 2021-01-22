    public static MyClrObject Map(this MyLinqObject o)
            {
                MyClrObject myObject = new MyClrObject()
                {
                    stringValue = o.String,
                    secondValue = o.Second
                };
                return myObject;
            }
