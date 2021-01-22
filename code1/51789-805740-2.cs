    [Serializable]
    [AttributeUsage(AttributeTargets.Property)]
    public class ChangeTrackingAttribute : OnMethodInvocationAspect
    {
        public override void OnInvocation( MethodInvocationEventArgs e )
        {
            if( e.Delegate.Method.ReturnParameter.ParameterType == typeof(void) )
            {
                  // we're in the setter
                  IChangeTrackable target = e.Delegate.Target as IChangeTrackable;
    
                  // Implement some logic to retrieve the current value of 
                  // the property
                  if( currentValue != e.GetArgumentArray()[0] )
                  {
                      target.Status = Status.Dirty;
                  }
                  base.OnInvocation (e);
            } 
        }  
    } 
