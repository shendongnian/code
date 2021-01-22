    public double Value1
     {
         get { return _value1;}
         set { _value1 = value;  RaisePropertyChanged("Value1"); ClaculateSum(); }
     }
     public double Sum
     {
         get { return _sum;}
         set { _sum= value;  RaisePropertyChanged("Sum"); }
     }
     public void CalculateSum()
     {
       Sum = Value1+Value2+Value3;
     }
