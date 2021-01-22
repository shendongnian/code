    public abstract class Command2<T1, T2> : ICommand
            {
                
                ...        
                public abstract T2 Execute2(T1 parameter);
                ...
        
             }
        
        public class DelegateCommand2<T1, T2> : Command2<T1, T2>
            {
                public DelegateCommand2(Func<T1, T2> execute, Predicate<T1> canExecute)
                {
        
                    _execute = execute;
                    _canExecute = canExecute;
                }
        
                public override T2 Execute2(T1 parameter)
                {
                    //_execute((T)parameter); Wayne
                    if (!CanExecute(parameter)) return default(T2);
                    else
                        return _execute((T1)parameter);
        
                }
             }
        
        Note that Execute2 returns the value just like a normal function. 
        
        *---------------------Here is how to use it.  ------------------------*/
        
        
                       
        private readonly ICommand _commandExample = new DelegateCommand2<int, Point3D>(commandExample_Executed, commandExample_CanExecute);
                        
        public Command2<int, Point_3D>CommandExample 
        { get { return (Command2<int, Point_3D>)_commandExample; } }
        
        static Point3D commandExample_Executed(int index) 
        {
                  return Fun1(index); //Fun1 generates a Point3D type return
        }
            
        static bool commandExample_CanExecute(int index)
        {
                  return true;
        }
