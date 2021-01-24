    var vehicleString = "Car";
    // use the fully-qualified name of the type here
    // (assuming Car is in the same assembly as this code, 
    //  if not add a ", MyAssembly" to the end of the string)
    var verhicleType = Type.GetType($"MyCompany.MySolution.Vehicle.Implementations.{vehicleString}");
    
    // assuming MyFactory is the name of the class 
    // containing the Register<T>-Method
    typeof(MyFactory).GetMethod("Register")
    	.MakeGenericMethod(verhicleType).Invoke(this);
