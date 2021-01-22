    private void BindList(NameValueCollection nvpList)
    {
       Dictionary<string,string> temp = new Dictionary<string,string>();
       foreach (string key in nvpList)
       {
          temp.Add(key,nvpList[key]);
       }
    
       resultGV.DataSource = temp;
       resultGV.DataBind();
    }
