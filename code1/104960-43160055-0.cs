    public class DisplayNamme : System.MulticastDelegate{
    
       // It is a contructor
       public DisplayNamme(Object @object, IntPtr method);
    
       // It is the method with the same prototype as defined in the source code. 
       public void Invoke(String name);
    
    // This method allowing the callback to be asynchronouslly.
    
     public virtual IAsyncResult BeginInvoke(String name, 
     AsyncCallback callback, Object @object); 
    
     public virtual void EndInvoke(IAsyncResult result); 
    
    }
