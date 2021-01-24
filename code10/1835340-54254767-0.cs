    if(langue == LangueAgence.FR)
                    {
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR"); 
                    }
                    else if(langue == LangueAgence.EN)
                    {
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    }                        
                        
                        AddElement.AddTextAgencyFB(ref cb, Properties.Resources.LINK_Nom_agence.ToUpper(), 239, 817, new BaseColor (49, 140, 231), 12, true,0);
                        AddElement.AddTextAgencyFB(ref cb, Properties.Resources.Link_Nom.ToUpper(), 112, 700, BaseColor.WHITE, 10, false);//Last name
     }
