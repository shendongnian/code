    //request.Headers.Add("date", getIsoStringFromDate(DateTime.Now)); <- EXCEPTION in .Net 3.5
     //WORKAROUND
     Type type = request.Headers.GetType();
     BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
     MethodInfo methodInfo = type.GetMethod("AddWithoutValidate", flags);
     object[] myPara = new object[2];
     myPara[0] = "date";
     myPara[1] = DateTime.Now.ToShortDateString();
     methodInfo.Invoke(request.Headers, myPara);
