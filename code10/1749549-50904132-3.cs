         private void PopulateProductsLists(List<PlanDefinition> listArticles)
                {
                    int labelIndex = 0;
                    int count = 0;
                    for (var i = 0; i < listArticles.Count; i++)
                    {
                       //Calling a view to display data
                        item = new PlanOrderTemplate();             
        
                        var lastHeight = "100";
                        var y = 0;
                        int column = 1;
                        var productTapGestureRecognizer = new TapGestureRecognizer();
                  
                    //Add label in the stack layout
                        ProduitsLayout.Children.Add((new Label
                        {
                            Text = listArticles[i].Name,
                            Style = Device.Styles.TitleStyle,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Color.Black
                        }));
        
        
                        for (int j = 0; j < listArticles[i].ArticlesAvailable.Count; j++)
                        {
                            
                            productTapGestureRecognizer.Tapped += OnProductTapped;
                 
                            item = new PlanOrderTemplate();
                       
                            listArticles[i].ArticlesAvailable[j].ThumbnailHeight = lastHeight;
                           //Applying binding to the view in order to display data
                                item.BindingContext = listArticles[i].ArticlesAvailable[j];
                                item.GestureRecognizers.Add(productTapGestureRecognizer);
                                 
            //This is mandatory you need to call the add the view page to the stack layout
                                ProduitsLayout.Children.Add(item);
        }
        }
    }
