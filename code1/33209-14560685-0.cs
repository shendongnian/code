    internal class Feedback : System.MulticastDelegate {  
       // Constructor  
       public Feedback(Object object, IntPtr method);  
     
       // Method with same prototype as specified by the source code  
       public virtual void Invoke(Int32 value);  
     
       // Methods allowing the callback to be called asynchronously  
       public virtual IAsyncResult BeginInvoke(Int32 value,  AsyncCallback callback, Object object);  
       public virtual void EndInvoke(IAsyncResult result);  
    }
