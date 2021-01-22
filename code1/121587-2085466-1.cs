    using Model;         
             
    namespace ModelLite         
    {         
        public class Car         
        {         
            private Model.Car car = new Model.Car();         
             
            public double Speed         
            {         
                get { return this.car.Speed; }         
                set { this.car.Speed = value; }         
            }         
             
        }         
    }    
     
