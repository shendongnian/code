			//TODO: FIND OUT ABOUT e.Message + e.StackTrace from Bromberg eggcafe
			int output = System.Convert.ToInt16 (
					System.Configuration.ConfigurationSettings.AppSettings["DebugOutput"] );
			//0 - do not debug anything just run the code 
			switch (output)
			{
				//do not debug anything	
				case 0:
					msg = String.Empty;
					break;
				//1 - output to debug window in Visual Studio 		
				case 1:
					System.Diagnostics.Debug.WriteIf ( System.Convert.ToBoolean
								( System.Configuration.ConfigurationSettings.AppSettings["Debugging"] ),
						DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n" );
					break;
				//2 -- output to the error label in the master 
				case 2:
					string previousMsg = System.Convert.ToString (
									System.Web.HttpContext.Current.Session["global.DebugMsg"] );
					System.Web.HttpContext.Current.Session["global.DebugMsg"] = previousMsg +
					DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n </br>";
					break;
				//output both to debug window and error label 
				case 3:
					string previousMsg1 = System.Convert.ToString (
									System.Web.HttpContext.Current.Session["global.DebugMsg"] );
					System.Web.HttpContext.Current.Session["global.DebugMsg"] = previousMsg1 +
							DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n";
					System.Diagnostics.Debug.WriteIf ( System.Convert.ToBoolean
							( System.Configuration.ConfigurationSettings.AppSettings["Debugging"] ),
					DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n </br>" );
					break;
				//TODO: implement case when debugging goes to database 
			} //eof switch 
		} //eof method WriteIf
