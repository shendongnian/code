/// Schedule the given action for the given time.
public async void ScheduleAction ( Action action , DateTime ExecutionTime )
{
	try
	{
		await Task.Delay ( ( int ) ExecutionTime.Subtract ( DateTime.Now ).TotalMilliseconds );
		action ( );
	}
	catch ( Exception )
	{
		// Something went wrong
	}
}
Bearing in mind it can only wait up to the maximum value of int 32 (somewhere around a month), it should work for your purposes.  Usage:
void MethodToRun ( )
{
    Console.WriteLine ("Hello, World!");
}
void CallingMethod ( )
{
    var NextRunTime = DateTime.Now.AddHours(1);
    ScheduleAction ( MethodToRun, NextRunTime );
}
And you should have a console message in an hour.
