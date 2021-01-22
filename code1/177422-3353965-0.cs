    using System.Reflection;
    // ...
    public override IPizza CreatePizza(PizzaType pizzaType, params object[] parameters) {
                return (IPizza)
                       Activator.CreateInstance(
                            Assembly
                                 .GetExecutingAssembly()
                                 .GetType(pizzaType.ToString()),
                            parameters);
            }
