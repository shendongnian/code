    static void CopyProperties<T>(ref T Target, T Source)
            {
                foreach (PropertyInfo PI in Target.GetType().GetProperties())
                {
                    if (PI.CanWrite && PI.CanRead)
                    {
                        PI.SetValue(Target, PI.GetValue(Source, null), null);
                    }
                }
            }
....
    static void Save(Test_TableData ChangedData)
            {
                using (DataClasses1DataContext D = new DataClasses1DataContext())
                {
                    Test_TableData UpdateTarget = D.Test_TableDatas.SingleOrDefault(i => i.ID == ChangedData.ID);
                    if (UpdateTarget != null)
                    {
                        CopyProperties<Test_TableData>(ref UpdateTarget, ChangedData);
                    }
                    else
                    {
                        D.Test_TableDatas.InsertOnSubmit(ChangedData);
                    }
                    D.SubmitChanges();
                }
        }
