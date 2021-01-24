     //Copy New ContentDefinition from selected ContentDefinition
                var CDF = RMSI.ContentDefinitionFactory;
                var altCDF = si.ContentDefinitionFactory;
               
                foreach (ContentDefinition CD in altCDF.NewList(""))
                {
                    CDFF= CDF.AddItem(System.DBNull.Value);
                    CDFF.Name = CD.Name;
                    CDFF.AutoCompleteType = CD.AutoCompleteType;
                    CDFF.Post();
                    //Copy New ContentRoot from selected ContentRoot
                    //ContentRoot is requirement
                    var crf = CD.ContentRootFactory;
                    var ncrf = CDFF.ContentRootFactory;
                  
                    foreach (ContentRoot CR in crf.NewList(""))
                    {
                        //Add associate a requirement
                        var ContentRoot = ncrf.AddItem(System.DBNull.Value);
                        ContentRoot.Name = CR.Name;
                        ContentRoot.RootEntityId = CR.RootEntityId;
                        ContentRoot.RootEntityType = CR.RootEntityType;
                        ContentRoot.Post();
                      
                    }
                }
