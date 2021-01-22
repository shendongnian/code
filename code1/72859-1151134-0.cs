static void Main(string[] args)
{            
  double t = 0; // time
  double v = 25; // muzzle velocity (m/s)
  double a = (Math.PI * 35 / 180.0); // launch angle in radians            
  double h0 = 0; // initial height (m)
  while (true)
  {
    PointF pt = new PointF((float)(v * Math.Cos(a) * t), 
                           (float)(h0 + (v * Math.Sin(a) * t) - (9.8 * t * t) / 2));
    t += .01;
    if (pt.Y &gt; Console.WindowHeight - 1)
      continue;
    if (pt.Y &lt; 0 || pt.X &lt; 0 || pt.X &gt; Console.WindowWidth - 1)
      break;
    Console.SetCursorPosition((int)pt.X, Console.WindowHeight - (int)pt.Y - 1);
    Console.Write("x");                
  };
  Console.ReadLine();
}
