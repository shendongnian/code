    void LoadOpLoadEntitiesCallBack(LoadOperation<MyEntity> loadOperation)
    {
      if (loadOperation.Entities.Count() > 0)
      {
        List<MyEntity> mList = new List<MyEntity>();
        MyEntity mE = new MyEntity();
        mE.Column1 = -1;
        mE.Column2 = "Default value";
        mList.Add(mE);
        for (int i = 0; i < loadOperation.Entities.Count(); i++)
        {
          mList.Add(loadOperation.Entities.ToList()[i]);
        }
        this.MyCombo.ItemsSource = mList.ToList();
      }
    }
