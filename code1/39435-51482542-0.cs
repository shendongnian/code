    using System;
    
    namespace VirtualExample
    {   
        class Vehicle
        {   
           public double distance=0.0;
           public double hour =0.0;
           public double fuel =0.0; 
    
           public Vehicle(double distance, double hour, double fuel)
           {
               this.distance = distance;
               this.hour = hour;
               this.fuel = fuel;
           }
    
           public void Average()
           {
               double average = 0.0;
               average = distance / fuel;
               Console.WriteLine("Vehicle Average is {0:0.00}", average);
           }
    
           public virtual void Speed()
           {
               double speed = 0.0;
               speed = distance / hour;
               Console.WriteLine("Vehicle Speed is {0:0.00}", speed);
           }
        } 
    
        class Car : Vehicle
        {
            public Car(double distance, double hour, double fuel)
                : base(distance, hour, fuel)
            {
            }
          public void Average()
            {
                double average = 0.0;
                average = distance / fuel;
                Console.WriteLine("Car Average is {0:0.00}", average);
            }
    
            public override void Speed()
            {
                double speed = 0.0;           
                speed = distance / hour;
                Console.WriteLine("Car Speed is {0:0.00}", speed);
            }
        } 
    
        class Program
       {
            static void Main(string[] args)
            {
                 double distance,hour,fuel=0.0;
                 Console.WriteLine("Enter the Distance");
                 distance = Double.Parse(Console.ReadLine());
                 Console.WriteLine("Enter the Hours");
                 hour = Double.Parse(Console.ReadLine());
                 Console.WriteLine("Enter the Fuel");
                 fuel = Double.Parse(Console.ReadLine());
                 Car objCar = new Car(distance,hour,fuel);
                 Vehicle objVeh = objCar;
                 objCar.Average();
                 objVeh.Average();
                 objCar.Speed();
                 objVeh.Speed();
                Console.Read();
            }       
        }
    }
