    using System;
    
    
    namespace ControllerFactory
    {
      class ClientEnvoker
      {
        static void Main ( string[] args )
        {
    
          Console.WriteLine ( " START " );
          ClientEnvoker objClientEnvoker = new ClientEnvoker ();
    
          ControllerFactory cf = new ControllerFactory ();
    
          Console.WriteLine ( " RUN METHOD 1 WITH CONTROLLER 1 WITH CONFIG 1 " );
          cf.RunMethod ( ControllerFactory.CFSetter.First );
    
          Console.WriteLine ( " RUN METHOD 2 WITH CONTROLLER 1 WITH CONFIG 2 " );
          cf.RunMethod ( ControllerFactory.CFSetter.Second );
    
    
          Console.WriteLine ( " END HIT A KEY TO EXIT " );
          Console.ReadLine ();
    
        } //eof method 
    
      } //eof class 
    
    
      class ControllerFactory
      {
        public enum CFSetter : int
        {
          First = 1,
          Second = 2
        }
    
        public void RunMethod ( CFSetter objCFSetter )
        {
          Controller c = this.FactoryMethod ( objCFSetter );
          c.Scream ();
        } //eof method 
    
        public Controller FactoryMethod ( CFSetter objCFSetter )
        {
          Controller controllerReturn = null;
          switch (objCFSetter)
          {
            case CFSetter.First:
              controllerReturn = new Controller1 ();
              break;
            case CFSetter.Second:
              controllerReturn = new Controller2 ();
              break;
            default:
              controllerReturn = new Controller1 ();
              break;
          }
          return controllerReturn;
        }
    
      } //eof class
    
      #region Controllers
      public abstract class Controller
      {
        public abstract void Scream ();
      }
    
    
      public class Controller1 : Controller
      {
    
        public override void Scream ()
        {
          Console.WriteLine ( "Controller1 screams according to version 1 logic" );
        }
      } //eof class 
    
      public class Controller2 : Controller
      {
    
        public override void Scream ()
        {
          Console.WriteLine ( "Controller2 screams according to version 2 logic" );
        }
      } //eof class 
    
      #endregion Controllers
    
      
    
    } //eof namespace  
 
