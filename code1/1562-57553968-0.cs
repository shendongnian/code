                    ICommonExtService commonExtService = ProxyHelper.GetCommonExtServiceProxy();
                    filledJSON = commonExtService.GetCandidateData(candidateCode.Trim());
                    JObject CanidateDataObj = new JObject();
                    if (string.IsNullOrEmpty(filledJSON) == false)
                    {
                        DataTable dt = new DataTable();
                        dt = JsonConvert.DeserializeObject<DataTable>(filledJSON);
                        DataTable DtC = dt.Clone();
                        foreach (DataColumn column in DtC.Columns)
                        {
                            column.DataType = typeof(string);
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            DtC.ImportRow(row);
                        }
                        try
                        {
                            if (DtC != null && DtC.Columns.Count > 0 && DtC.Rows.Count > 0)
                            {
                                //Json Formating code
                                var filter = (from r1 in DtC.AsEnumerable()
                                              group r1 by new
                                              {
                                                  CandidateCode = r1.Field<string>("CandidateCode"),
                                                  FirstName = r1.Field<string>("FirstName"),
                                                  MiddleName = r1.Field<string>("MiddleName"),
                                                  LastName = r1.Field<string>("LastName"),
                                                  FullName = r1.Field<string>("FullName"),
                                                  DistributionCode = r1.Field<string>("DistributionCode"),
                                                  GoCode = r1.Field<string>("GoCode"),
                                                  SSN = r1.Field<string>("SSN")
                                              } into g
                                              select new
                                              {
                                                  FirstName = g.Key.FirstName,
                                                  MiddleName = g.Key.MiddleName,
                                                  LastName = g.Key.LastName,
                                                  FullName = g.Key.FullName,
                                                  CandidateCode = g.Key.CandidateCode,
                                                  DistributionCode = g.Key.DistributionCode,
                                                  GoCode = g.Key.GoCode,
                                                  SSN = g.Key.SSN,
                                                  AddressList = from a1 in g.ToList().
                                                              Where(e1 => (e1.Field<string>("AddressLine1") == ""
                                                              && e1.Field<string>("State") == ""
                                                              && e1.Field<string>("City") == ""
                                                              && e1.Field<string>("ZipCode") == ""
                                                              && e1.Field<string>("County") == ""
                                                              && e1.Field<string>("Country") == "") == false
                                                              )
                                                                group a1 by new
                                                                {
                                                                    AddressLine1 = a1.Field<string>("AddressLine1"),
                                                                    State = a1.Field<string>("State"),
                                                                    City = a1.Field<string>("City"),
                                                                    ZipCode = a1.Field<string>("ZipCode"),
                                                                    County = a1.Field<string>("County"),
                                                                    Country = a1.Field<string>("Country")
                                                                } into f
                                                                select new
                                                                {
                                                                    AddressLine1 = f.Key.AddressLine1,
                                                                    State = f.Key.State,
                                                                    City = f.Key.City,
                                                                    ZipCode = f.Key.ZipCode,
                                                                    County = f.Key.County,
                                                                    Country = f.Key.Country
                                                                },
                                                  EmploymentHistoryList = from e1 in g.ToList().
                                                              Where(e1 => (e1.Field<string>("EmployerName") == ""
                                                              && e1.Field<string>("JobTitle") == ""
                                                              && e1.Field<string>("City") == ""
                                                              && e1.Field<string>("State") == ""
                                                              && e1.Field<string>("County") == ""
                                                              && e1.Field<string>("ZipCode") == ""
                                                              && e1.Field<string>("ManagerFirstName") == ""
                                                              && e1.Field<string>("ManagerLastName") == "") == false
                                                              )
                                                                          group e1 by new
                                                                          {
                                                                              EmployerName = e1.Field<string>("EmployerName"),
                                                                              JobTitle = e1.Field<string>("JobTitle"),
                                                                              City = e1.Field<string>("City"),
                                                                              State = e1.Field<string>("State"),
                                                                              County = e1.Field<string>("County"),
                                                                              ZipCode = e1.Field<string>("ZipCode"),
                                                                              ManagerFirstName = e1.Field<string>("ManagerFirstName"),
                                                                              ManagerLastName = e1.Field<string>("ManagerLastName")
                                                                          } into h
                                                                          select new
                                                                          {
                                                                              EmployerName = h.Key.EmployerName,
                                                                              JobTitle = h.Key.JobTitle,
                                                                              City = h.Key.City,
                                                                              State = h.Key.State,
                                                                              County = h.Key.County,
                                                                              ZipCode = h.Key.ZipCode,
                                                                              ManagerFirstName = h.Key.ManagerFirstName,
                                                                              ManagerLastName = h.Key.ManagerLastName
                                                                          }
                                              });
                                if (filter != null)
                                {
                                    JArray jr = JArray.FromObject(filter);
                                    CanidateDataObj = (JObject)jr[0];
                                }
                                if (_responsemsg.Content == null && CanidateDataObj.HasValues == true)
                                {
                                    ResponseData = new JObject();
                                    ResponseData.Add("ResponseCode", ResponseCode.Success.ToString());
                                    ResponseData.Add("ResponseMessage", "Data present");
                                    ResponseData.Add("Data", CanidateDataObj);
                                    _responsemsg.StatusCode = System.Net.HttpStatusCode.OK;
                                    _responsemsg.Content = new ObjectContent<JObject>(ResponseData, formatter, "application/json");
                                    return _responsemsg;
                                }
                            }
                            else
                            {
                                ResponseData = new JObject();
                                ResponseData.Add("responseCode", ResponseCode.Failure.ToString());
                                ResponseData.Add("responseMessage", "No candidate found with given Code");
                                _responsemsg.StatusCode = System.Net.HttpStatusCode.NotFound;
                                _responsemsg.Content = new ObjectContent<JObject>(ResponseData, formatter, "application/json");
                                return _responsemsg;
                            }
                        }
                        catch (Exception Ex)
                        {
                            ResponseData = new JObject();
                            ResponseData.Add("responseCode", ResponseCode.Failure.ToString());
                            ResponseData.Add("responseMessage", Ex.Message.ToString());
                            _responsemsg.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                            _responsemsg.Content = new ObjectContent<JObject>(ResponseData, formatter, "application/json");
                            return _responsemsg;
                        }
                    }
                    else if(string.IsNullOrEmpty(candidateCode)==false)
                    {
                        ResponseData = new JObject();
                        ResponseData.Add("responseCode", ResponseCode.Failure.ToString());
                        ResponseData.Add("responseMessage", "No candidate found with given Code");
                        _responsemsg.StatusCode = System.Net.HttpStatusCode.NotFound;
                        _responsemsg.Content = new ObjectContent<JObject>(ResponseData, formatter, "application/json");
                        return _responsemsg;
                    }
                    else
                    {
                        ResponseData = new JObject();
                        ResponseData.Add("responseCode", ResponseCode.Failure.ToString());
                        ResponseData.Add("responseMessage", "Please provide valid candidate code");
                        _responsemsg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        _responsemsg.Content = new ObjectContent<JObject>(ResponseData, formatter, "application/json");
                        return _responsemsg;
                    }
