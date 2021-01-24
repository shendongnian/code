    var contacts = new Contacts
    {
    	phoneMobiles = new List<PhoneMobile>
    	{
    		new PhoneMobile { phoneMobile = "8103267511" }
    	},
    	phoneLandlines = new List<PhoneLandline>()
    	{
    		new PhoneLandline { phoneLandLineNumber = "8103267511" }
    	},
    	emails = new List<Email>()
    	{
    		new Email { email = "testing@gmail.com" }
    	}
    };
    
    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(contacts);
