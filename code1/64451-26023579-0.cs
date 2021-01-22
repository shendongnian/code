      ClassData updatesData =  new ClassData();
      this.BeginInvoke(new Action<ClassData>(FillCurve),
                               new object[] { updatesData });
 
...
    public void FillCurve(ClassData updatesData)
    {
    }
