    private TodoItem _todoItem;
    public TodoItem TodoItem
    {
       get => _todoItem;
       set
       {
         _todoItem = value;
         Title = value?.name ?? "";
       }
     }
