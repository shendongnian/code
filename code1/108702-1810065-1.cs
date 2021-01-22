    public void Main()
    {
      printNumber(1);
    }
    
    private void printNumber(int x)
    {
      Console.WriteLine(x.ToString());
      if(x<101)
      {
        x+=1;
        printNumber(x);
      }
    }
