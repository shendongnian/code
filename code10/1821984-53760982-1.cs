    class FormBaseDetail 
    {
       private void Guard(Action a)
       {
           try { a.Invoke(); }
           catch(Exception e)
           {
              throw new Exception("Exception on '" + this.GetType() + "'", e);
           }
       }
 
       // pretty much everywhere in base class
       public void PrepareFormLoad() 
       {
          Guard(() => { ... });
       }
    }
