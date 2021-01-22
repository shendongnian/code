    private void A_FooChanged(object sender, EventArgs e)
    {
       if (!SignalSet.Contains(B_BarChanged))
       {
          SignalSet.Add(A_FooChanged);
          B.Bar = f(A.Foo);
          SignalSet.Remove(A_FooChanged);
       }
    }
