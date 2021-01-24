            public IQueryable<Indicators> SetOfIndicatorsWithTranslations()
            {
                return ctx.Set<Indicators>().Select(ind => new Indicators() {
                                        Text1Ref= ind.Text1Ref, // whatever the property is 
                                        Text1RefList = ctx.Set<Translation>().Where(t => t.TranslationId == ind.Text1Ref),  
                                        Text2Ref= ind.Text2Ref,  
                                        Text2RefList = ctx.Set<Translation>().Where(t => t.TranslationId == ind.Text2Ref),  
                                    });
            }
