    class FormB
    {
       ...
       private void SomethingHappened()
       {
          ((FormA)MdiParent).TellFormASomethingHappened();
       }
    ...
    class FormA
    {
       private FormC mFormC;
       ...
       public void TellFormASomethingHappened()
       {
          mFormC.TellFormCSomethingHappened();
       }
    ...
    class FormC
    {
        public void TellFormCSomethingHapened()
        {
           // do something
        }
    ...
