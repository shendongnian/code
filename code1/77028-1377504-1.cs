class IRepository
{ 
    public event THING Created; 
}
class THING : EventArgs
{ 
    public static THING Empty 
    { 
        get { return new THING(); } 
    } 
}
