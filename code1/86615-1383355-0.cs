class Robot
{
 public string Name { get; }
 private Robot() 
 { 
   // some code
 }
 public static Robot CreateAndInitRobot(string name)
 {
   Robot r = new Robot();
   r.Name = name;
   return r;
 }
}
