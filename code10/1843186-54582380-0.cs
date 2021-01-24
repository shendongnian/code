    using System.Runtime.InteropServices;   
    
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("your-GUID-1")]
    public interface _Visible_Methods
    {
        //--------< _Visible_Methods >--------
        //*visible COM Methods of this Control under Office,Excel, Word
        string get_Hello();
        //--------</ _Visible_Methods >--------
    }
