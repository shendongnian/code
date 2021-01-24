C#
string viewString = System.IO.File.ReadAllText(viewPath); // view to string
string cssSiteString = System.IO.File.ReadAllText(cssSitePath); // css-file to string
Engine.Razor.AddTemplate(nameoftemplate, viewString);
Engine.Razor.Compile(viewPath);
var result = Engine.Razor.Run(viewPath, null, model, viewBag);
var pm = new PreMailer.Net.PreMailer(result); 
var completeMail = pm.MoveCssInline(css: cssSiteString); // this line moves the css inline
