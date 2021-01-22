    >     public class MyClass
    >     {
    >         public event EventHandler (point 2) MyEvent; (point 1)
    >     
    >         (point 3 + 4)
    >         protected virtual void OnMyEvent()
    >         {
    >             EventHandler temp = MyEvent;
    >             if (temp != null)
    >                 temp(this, EventArgs.Empty);
    >         }
    >     
    >         public void SomeMethodThatWillRaiseTheEvent()
    >         {
    >             ....
    >             OnMyEvent();
    >         }
    >     }
