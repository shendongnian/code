    this.NavigationController.TransitioningDelegate = new MyOwnDelegate();
 
      internal class MyOwnDelegate : IUIViewControllerTransitioningDelegate
        {
            public IntPtr Handle => throw new NotImplementedException();
    
            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }
