        public class SomeCommand : ICommand
        {
            ....
            
             public void Execute(object parameter)
             {
                //...actions...
                MyViewModelinstance.XYZ = String.Empty;
            }
        }
