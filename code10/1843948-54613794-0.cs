    namespace Assignment1
    {
        // TODO Implement pizza tracker
        /// <summary>
        /// The main Pizza class.
        /// Contains methods for adding toppings to the pizza, the number of minutes
        /// required to prepare the pizza and a constructor that initializes the
        /// pizza's size to a given value.
        /// </summary>
        public class Pizza
        {
            Size size;
            List<Topping> toppings = new List<Topping>();
            double minutes;
    
            // constructor that initializes the pizza's
            // size to a given value.
            public void Pizzasize(Size psize)
            {
                size = psize;
            }
    
            // function that adds toppings.
            public void AddTopping(Topping top)
            {
                toppings.Add(top);
            }
    
            // function that gets the number of minutes to prepare a pizza.
            public double Numminutes()
            {
                if (size == Size.Small)
                {
                    return 2 + (toppings.Count);
                }
    
                if (size == Size.Medium)
                {
                    return 3 + (toppings.Count);
                }
    
                if (size == Size.Large)
                {
                    return 4 + (toppings.Count);
                }
    
                return 0;
            }
        }
    
        /// <summary>
        /// The main Order class.
        /// Contains a method that adds a pizza to the order.
        /// </summary>
        public class Order
        {
            List<Pizza> pizzas = new List<Pizza>();
            double ready;
    
            // function that adds pizza's to the order.
            public void Addpizza(Pizza pizza)
            {
                pizzas.Add(pizza);
            }
        }
    
        /// <summary>
        /// The main Employee class.
        /// Contains methods for adding employees to the store, and for placing orders.
        /// </summary>
        public class Employee
        {
    
            List<Pizza> makepizzas = new List<Pizza>();
            public int Id;
            public string employeeName;
    
            public void employee(int id, string name)
            {
                this.Id = id;
                this.employeeName = name;
            }
    
            public void Addtodo(Pizza pizzatd)
            {
                makepizzas.Add(pizzatd);
            }
        }
    
        /// <summary>
        /// The main Store class.
        /// Contains methods for adding employees to the store, and for placing orders.
        /// </summary>
        public class Store
        {
            List<Employee> storeemployee = new List<Employee>();
            List<Order> orders = new List<Order>();
            Employee employee = Employee.employeeName;
    
            // Function to add an employee to the store. This function should
            // take an Employee object as a parameter.
            public void AddEmployee(Employee emp)
            {
                storeemployee.Add(emp)
            }
    
            // Function to place an order. This function should take an Order object as a parameter, set
            // the order's field indicating how many minutes until the order is ready, and return the number of
            // minutes.
            public void Addorder(Orer order)
            {
                storeemployee.Add()
            }
        }
    
        public enum Size
        {
            Small,
            Medium,
            Large
        }
    
        public enum Topping
        {
            Cheese,
            Pepperoni,
            Mushroom,
            GreenPepper,
            Bacon,
            Tomato,
            Ham,
            Pineapple
        }
