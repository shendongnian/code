    public class SetFocusTrigger : TargetedTriggerAction<Control>
    {
     protected override void Invoke(object parameter)
     {
        if (Target == null) return;
        Target.Focus();
     }
    }
