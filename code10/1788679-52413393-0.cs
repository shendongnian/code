    static Dictionary<Tuple<Shape, Color, Material>, Action> s_Actions = new
      Dictionary<Tuple<Shape, Color, Material>, Action>() {
        {Tuple.Create(Shape.square, Color.blue, Material.glass), () => { ... } },
         ...  
        {Tuple.Create(Shape.any, Color.red, Material.metal), () => { ... } },
         ...
      };
    private static void RunAction(MyItem item) {
      Action action;
      // Either exact match or match with Any 
      if (!s_Actions.TryGetValue(Tuple.Create(item.ItemShape, item.ItemColor, item.ItemMaterial), 
                                 out action))
        action = s_Actions.FirstOrDefault(pair => pair.Key.Item1 == Color.any &&
                                                  pair.Key.Item2 == item.ItemColor &&
                                                  pair.Key.Item3 == item.ItemMaterial) 
      // Execute action if it's found
      if (action != null) 
        action();  
    }
