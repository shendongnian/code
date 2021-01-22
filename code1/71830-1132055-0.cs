		{
                //fieldy
                string nazov_fieldu;
                decimal celkovy_pocet_fieldov = selenium.GetXpathCount ("//input[@type='text']");
                int b = 1;
                string pomoc = "";
                for (b = 1;b<=celkovy_pocet_fieldov;b++)
                {
                        nazov_fieldu = selenium.GetAttribute("xpath=//input[@type='text'" + pomoc +"]@name");
                        pomoc = pomoc + " and @name!= '" + nazov_fieldu + "'";
                        Console.WriteLine(nazov_fieldu);
                }
                Console.WriteLine ("Celkovy pocet fieldov je = " + celkovy_pocet_fieldov);
		}
