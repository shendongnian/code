    class Vehicle: IVehicle {
    
         public int IVehicle.getWheel()
         {
             return wheel;
         }
    
         public void printWheel()
         {
             Console.WriteLine( ((IVehicle)this).getWheel() );
         }
    }
