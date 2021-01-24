    interface IItem
    {
          bool IsEdible {get;}
    }
    class Food : IItem
    {
        public bool IsEdible => true;
        public void Eat();
    }
    class Gun : IItem
    {
          public bool IsEdible => false;
    }
    ...
    {
       IItem item = ...
       if(item.IsEdible)
       {
           Food food = (Food)item;
           food.Eat();
       }
    }
