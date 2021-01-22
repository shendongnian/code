    // need a remove method for each type. 
    void Remove( ref Com1 x ) { ...; x = null; }
    void Remove( ref Con2 x ) { ...; x = null; }
    void Remove( ref Com3 x ) { ...; x = null; }
    // a generics version using ref.
    void RemoveComRef<ComT>(ref ComT t) where ComT : class
    {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(t);
        t = null; 
    }
    Com1 c1 = new Com1();
    Com2 c2 = new Com2();
    Remove( ref c1 );
    RemoveComRef(ref c2); // the generics version again.
