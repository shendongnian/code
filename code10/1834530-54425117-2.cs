c#
for (var i = 0; i<100; i++)
{
   // do a network-roundtrip/remoting/io/etc
}
and the solution is to change it to:
c#
// do a network-roundtrip/remoting/io/etc
for (var i = 0; i<100; i++)
{
    // do something with the result of the above call
}
So if I've understood you correctly, the data `Global.holidayGlobals.Values` comes from another process, like a memory cache. If so, your easiest bet is to change your code to:
c#
int limit=450;
public bool functionUI()
{
    var holidays = Global.holidayGlobals.Values;
    for(int i=0;i< limit ; i++)
    {
        functionApp(i, holidays);
    }
}
public static bool functionApp(int i, IEnumerable<HolidayEntity> holidays)
{
    foreach(var h in holidays)
    {
        if(h.Value == i)
        {
             return false;
        }
    }
    return true;
}
We are still doing too much work in the loops (we can improve the algorithm by creating a dictionary and just looking it up) but for your number (450) this is negligible compared to the time of one roundtrip to memory cache.
**UPDATE**
From the comments to the question, it appears that `holidays` is `Dictionary<int, HolidayEntity>` if so, the code can become much better like this:
c#
public bool functionUI()
{
    var holidays = Global.holidayGlobals.Values;
    
    for(int i=0;i< limit ; i++)
    {
        functionApp(i, holidays);
    }
}
public static bool functionApp(int i, IEnumerable<HolidayEntity> holidays)
{
    if (holidays.TryGetValue(i, out var h))
    {
        return false;
    }
    return true;
}
