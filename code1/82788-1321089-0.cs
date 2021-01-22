Method()
{
   stmt1();
   stmt2();
   int time = DateTime.Now.Millisecond;
   while (15*1000 > DateTime.Now.Millisecond - time)
   {
       Thread.Sleep(10)
       Application.DoEvents();
   }
   stmt3();
}
