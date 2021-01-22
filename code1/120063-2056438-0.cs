    public abstract class YourBaseClass
    {
        public void Update()
        {
            // Do some stuff
            //
            // Invoke inherited class's  method
            UpdateCore();
        }
        protected abstract void UpdateCore();
    }
    public class YourChildClass : YourBaseClass
    {
         protected override void UpdateCore()
         {
             //Do the important stuff
         }
    }
    //Somewhere else in code:
    var ycc = new YourChildClass();
    ycc.Update();
