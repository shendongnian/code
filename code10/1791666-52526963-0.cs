    public class Products{
    private int loopCounter=1;
    private int loop=10;
    public int ProductCount {get;set;}
    public int GetProducts(int Take, int Skip)
    {
        if(loopCounter >= loop) return;
        loopCounter++;
        //code that sets ProductCount is removed
        //Depending on ProductCount, Take and Skip values are
        //computed and passed to GetProducts. This code removed for brevity and am hard coding them
        GetProducts(10,5);
        //code to process GetProducts output removed
    } 
