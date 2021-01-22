public void DoStuff(IPerson person)
{
    new Timer(ProcessPerson, person, 0, 20000);
}
public void ProcessPerson(object threadState)
{
   IPerson person = threadState as IPerson;
   // do your stuff
}
