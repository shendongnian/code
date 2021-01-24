    private string _phonePrefix;
    public string PhonePrefix { get; set; }
    public string PhoneNumber { get; set; }
    public Country Country { get; set; } = new Country();
    public List<Country> Countries { get; set; } = new List<Country>();
    public List<string> Prefixes { get; set; } = new List<string>();
    
    public override async Task Initialize()
    {
        await base.Initialize();
        IsUserLogedIn = await _authService.IsUserLoggedIn();
        if (IsUserLogedIn)
        {
            //get user data from server, show user data
            await GetUserData();
        }
        
        //get countries, prefixes
        if (Countries.Count <= 0 || Prefixes.Count <= 0)
        {
            _registrationFormData = await _registrationService.GetRegistrationFormData();
            ProcessFormData();
        }
        AddValidationRules();
    }
    private async Task GetUserData()
    {
        try
        {
            var userDataResult = await _registrationService.GetLoggedInUserData();
            if (userDataResult != null)
            {
                if (!userDataResult.HTTPStatusCode.Equals(HttpStatusCode.OK))
                {
                    Mvx.IoCProvider.Resolve<IUserDialogs>().Alert(userDataResult.Error?.Message);
                }
                else
                {
                        //PhonePrefix = userDataResult.user.country_code_phone;
                        //can't bind it here to the public binded property because the SelectedItem binding fails. 
                        //I first assign it to a private field and then use it in the ProcessFormData method
                        _phonePrefix = userDataResult.user.country_code_phone;
                        PhoneNumber = userDataResult.user.phone;
                        Country.id = userDataResult.user.person.addresses[0].country_id;
                        Country.name = userDataResult.user.person.addresses[0].country_name;
                }
            }
        }
        catch (Exception e)
        {
            Log.Error<RegistrationViewModel>("GetUserData", e);
        }
    }
        private void ProcessFormData()
        {
            if (_registrationFormData != null)
            {
                Countries = _registrationFormData.Countries?.ToList();
                var userCountry = Countries?.Where(c => c.id == Country?.id).FirstOrDefault();
                Country = IsUserLogedIn && Country != null ? userCountry : Countries?[0];
                var prefixes = new List<string>();
                if (Countries != null)
                {
                    foreach (var country in Countries)
                    {
                        //spinner binding doesn't allow null values
                        if (country.phone_prefix != null)
                        {
                            prefixes.Add(country.phone_prefix);
                        }
                    }
                }
                //we need to assign the binded Prefixes at once otherwise the binding for the SelectedItem fails
                Prefixes = prefixes;
                if (Prefixes.Count > 0 && !IsUserLogedIn && string.IsNullOrWhiteSpace(_phonePrefix))
                {
                    PhonePrefix = Prefixes?[0];
                }
                else
                {
                    PhonePrefix = _phonePrefix;
                }
            }
        }
