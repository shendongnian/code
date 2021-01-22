    public interface IEditActions
    {
      void Action_Commit() {}
      void Action_Undo() {}
    }
    public interface IStateMachine
    {
      void Initialize(IEditActions editActions);
    }
    public class EditField : IEditField
    {
      private class EditActions : IEditActions
      {
        EditField _editField;
        public EditActions(EditField editField)
        {
          _editField = editField;
        }
        public void Action_Commit()
        {
          _editField.Action_Commit();
        }
        public void Action_Undo()
        {
          _editField.Action_Undo();
        }
      }
      public EditField() {}
      public EditField(IStateMachine stateMachine)
      {
        stateMachine.Initialize(new EditActions(this));
      }
      private void Action_Commit() {}
      private void Action_Undo() {}
    }
