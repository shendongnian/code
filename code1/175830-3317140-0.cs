    class Form{
       public event EventHandler<EventArgs> MouseMove;
       public virtual void OnMouseMove()
       {
           if(MouseMove != null)
           {
               MouseMove(this, new EventArgs());
           }
       }
    }
    
    class Application{
       public Application()
       {
           Form form = new Form();
           form.MouseMove += //Hook your own Method
       }
    }
