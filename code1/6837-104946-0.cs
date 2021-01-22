    public class DeleteCommand : ICommand
    {
       public void Execute(Entity entity)
       {
          IDeletable del = entity as IDeletable;
          if (del != null) del.Delete();
       }
    }
