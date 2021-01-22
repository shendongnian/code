    public sealed class MarioPizzeria : IWindow, IRestaurant  {
        //Explicit inteface member implementation for IWindow      
        Object IWindow.GetMenu();
        //Explicit inteface member implementation for IRestaurant
        Object IRestaurant.GetMenu();
        //An optional method that has nothing to do with an interface
        public Object GetMenu(); 
    }
