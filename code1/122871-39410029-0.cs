    var vm = new MyFormViewModel
    {
        OperatingSystem = "IOS",
        OperatingSystem_choices = new[]{"IOS", "Android",};
    };
    Html.PropertiesFor(vm).Render(Html);
 but you can also create the properties programatically, so you could load settings from a database then create `PropertyVm`. 
This is a snippet from a Linqpad script. 
	//import-package FormFactory
	//import-package FormFactory.RazorGenerator
	
	
	void Main()
	{
		var properties = new[]{
			new PropertyVm(typeof(string), "username"){
				DisplayName = "Username",
				NotOptional = true,
			},
			new PropertyVm(typeof(string), "password"){
				DisplayName = "Password",
				NotOptional = true,
				GetCustomAttributes = () => new object[]{ new DataTypeAttribute(DataType.Password) }
			}
		};
		var html = FormFactory.RazorEngine.PropertyRenderExtension.Render(properties, new FormFactory.RazorEngine.RazorTemplateHtmlHelper());	
		
		Util.RawHtml(html.ToEncodedString()).Dump(); //Renders html for a username and password field.
	}
	
	 
Theres a [demo site](http://formfactory.apphb.com/) with examples of the various features you can set up (e.g. nested collections, autocomplete, datepickers etc.)
