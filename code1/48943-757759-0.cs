    public enum Baseenum
    {
       x, y, z
    }
    
    public enum Consume
    {
       x = Baseenum.x,
       y = Baseenum.y,
       z = Baseenum.z
    }
    
    public void Test()
    {
       Baseenum a = Baseenum.x;
       Consume newA = (Consume) a;
    
       if ((Int32) a == (Int32) newA)
       {
       MessageBox.Show(newA.ToString());
       }
    }
