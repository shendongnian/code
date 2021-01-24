    var vehicleString = "Car";
    // use the fully-qualified name of the type here
    var verhicleType = Type.GetType($"MyCompany.MySolution.Vehicle.Implementations.{vehicleString}");
    
    // assuming MyFactory is the name of the class 
    // containing the Register<T>-Method
    typeof(MyFactory).GetMethod("Register")
    	.MakeGenericMethod(verhicleType).Invoke(this);
