    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication10
    {
        //Interfaces
        public interface ICar
        {
            string name { get;}
            IWheel wheel { get;}
        }
        public interface IWheel
        {
            string brand { get;}
        }
        //Implementations
        public class Michelin : IWheel
        {
            #region IWheel Members
            public string brand
            {
                get { return "michelin"; }
            }
            #endregion
        }
        public class Toyota : ICar
        {
            Michelin m = new Michelin();
            #region ICar Members
            public string name
            {
                get { return "toyota"; }
            }
            public IWheel wheel
            {
                get { return m; }
            }
            #endregion
        }
        //A user of the interfaces. Only cares about ICar but knows implicitly about IWheel
        public class Stand
        {
            public Stand()
            {
                cars = new List<ICar>(2);
                cars.Add(new Toyota());
                cars.Add(new Toyota());
            }
            List<ICar> cars;
            public string ShowCars()
            {
                StringBuilder str = new StringBuilder();
                foreach (ICar iterCar in cars)
                {
                    str.AppendLine(string.Format("car {0} with wheel {1}",
                        iterCar.name, iterCar.wheel.brand));
                }
                return str.ToString();
            }
        }
        //entry point. creates a stand and shows the cars, testing that properties are visible
        class Program
        {
            static void Main(string[] args)
            {
                Stand myLittleStand = new Stand();
                Console.WriteLine(myLittleStand.ShowCars());
            }
        }
    }
