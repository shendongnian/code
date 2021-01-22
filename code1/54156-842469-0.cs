    public DateTime _birthDate;
    if (string.IsNullOrEmpty(datBirthDate.Text))
        _birthDate = DateTime.MinValue;
    else
        _birthDate = Convert.ToDateTime(datBirthDate.Text);
    dgvSearchResults.DataSource=ConnectBLL.BLL.Person.Search(_firstName,_middleName,_lastName,_sSN,_birthDate,_applicationID,_applicationPersonID,_fuzzy);
