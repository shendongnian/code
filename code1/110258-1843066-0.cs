    class Order
    {
        public static Order CreateOrder(string filename)
        {
             Stream stream = new FileStream(filename);
             string typeinfo = stream.ReadLine();
             Type t=null;
             if(typeinfo=="LimitOrder")  // this can be improved by using "GetType"
                t=typeof(LimitOrder);
             else if(typeinfo==/* what ever your types are*/
                t= //...
             ConstructorInfo consInfo = t.GetConstructor(new Type[0]);
             Order o= (Order)consInfo.Invoke(new object[0]);
             o.Load(stream);
             stream.Close();
             return o;
        }
    }
