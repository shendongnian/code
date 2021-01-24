    public class MyButton : Button
    {
       
        protected override void OnProcessKeyboardAccelerators(ProcessKeyboardAcceleratorEventArgs args)
        {
           
            if(args.Key == VirtualKey.Space)
            {
                args.Handled = true;
            }
            base.OnProcessKeyboardAccelerators(args);
        }
       
    }
