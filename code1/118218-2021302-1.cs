    class A
    {
     protected int a;
          
     protected virtual string GetForShow()
     {
      a = 5;
      return a.ToString();
     }
     public void Show()
     {
      var forShow = GetForShow();
      MessageBox.Show(forShow);
     }
    }
    class B
    {
     protected char b;
     protected override string GetForShow()
     {
      b = 'z';
      return base.BeforeShow() + b;
     }
    }
