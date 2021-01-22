      private void BindList(NvpList nvpList)
      {
         IDictionary dict = new Dictionary<string, string>();
         foreach (String s in nvpList.AllKeys)
            dict.Add(s, nvpList[s]);
         resultGV.DataSource = dict;
         resultGV.DataBind();
      }
