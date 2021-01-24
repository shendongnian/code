    public TodoItem MyTodoItem
        {
            get => _todoItem;
            set
            {
                _todoItem = value;
                ID = value.id;
            }
        }
