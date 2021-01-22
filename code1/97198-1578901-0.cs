     SPList list = web.Lists["ListName"];
                        //SPListItem item = list.Items.Add();
                        //item["PercentComplete"] = .45; 
                        // 45%//item.Update();
                       SPQuery oQuery = new SPQuery();
                        
                            oQuery.Query = @"<Where>               
                                        <Eq>                   
                                            <FieldRef Name='Title' />                   
                                            <Value Type='Text'>Design</Value>              
                                        </Eq>            
                                      </Where>";
                            SPListItemCollection collListItems = list.GetItems(oQuery);
                            foreach (SPListItem item in collListItems)
                        {    item["PercentComplete"] = .55; // 45%    
                            item.Update();}
