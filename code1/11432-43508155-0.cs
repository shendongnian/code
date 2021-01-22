    Dictionary<string, string> dic = new Dictionary<string, string>();
    foreach(var id in new string[]{"F2","F3","F6","F12"})
    {
           foreach (var key in Request.Params.AllKeys)
                        {
                            if (key != null && key.ToString().Contains(id))
                                dic.Add(id, Request[key.ToString()].ToString()); 
                        }
    }
