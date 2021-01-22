    using (var c = new MyDataContext())
    {
        var q = from t in c.Tests
                select new 
                       {
                           TestId = t.TestId,
                           SubTests = from st in t.SubTests 
                                      where st.TestId = t.TestId 
                                      select new 
                                      {
                                          SubTestId = st.SubTestId
                                      }
                        };
    }
