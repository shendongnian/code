abstract class Base
{
    private bool _initialized;
    protected abstract void InitilaizationStep1();
    private void InitilaizationStep2() { return; }
    protected abstract void InitilaizationStep3();
    protected Initialize()
    {
        // it is safe to call virtual methods here
        InitilaizationStep1();
        InitilaizationStep2();
        InitilaizationStep3();
        // mark the object as initialized correctly
        _initialized = true;
    }
    
    public void DoActualWork()
    {
        if (!_initialized) Initialize();
        Console.WriteLine("We are certainly initialized now");
    }
}
