    Dictionary<MyEnum, Type> mapper = new Dictionary<MyEnum, Type>();
    mapper.Add(1, typeof(CarA));
    mapper.Add(2, typeof(BarB)); 
    public class Car<T> where T : class
    {       
        public T Detail { get; set; }
        public Car(T data)
        {
           Detail = data;
        }
    }
    public class CarA
    {  
        public int PropA { get; set; }
        public CarA(){}
    }
    public class CarB
    {
        public int PropB { get; set; }
        public CarB(){}
    }
    
    var jsonObj = {"Type":"1","PropA":"10"}
    MyEnum t = GetTypeOfCar(jsonObj);
    Type objectT = mapper[t]
    Type genericType = typeof(Car<>);
    Type carTypeWithGenerics = genericType.MakeGenericType(objectT);
    Activator.CreateInstance(carTypeWithGenerics , new Object[] { JsonConvert.DeserializeObject(jsonObj, objectT) });
