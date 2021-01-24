    if (dataReader == null)
        req.CreateResponse(HttpStatusCode.NoContent);
    else
    {
        List<ERPCompanySettingsResponse> settingsList = new List<ERPCompanySettingsResponse>();
    
        while (dataReader.Read())
        {
            settingsList.Add(new ERPCompanySettingsResponse
                                {
                                    SettingName = dataReader[0] != DBNull.Value ? dataReader[0].ToString() : null,
                                    SettingValue = dataReader[1] != DBNull.Value ? dataReader[1].ToString() : null,
                                    VATNumber = vatNumber
                                });
                            }
    
           return req.CreateResponse(HttpStatusCode.OK, settingsList.ToArray());
