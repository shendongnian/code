            public IQueryable<Indicators> SetOfIndicatorsWithTranslations()
            {
                return ctx.Set<Indicators>().Select(ind => new Indicators() {
                                        T1Ref = ind.Text1Ref, // whatever the property is 
                                        T1RefList = ctx.Set<Translation>().Where(t => t.TranslationId == ind.Text1Ref,  
                                        T2Ref = ind.Text2Ref,  
                                        T2RefList = ctx.Set<Translation>().Where(t => t.TranslationId == ind.Text2Ref,  
                                    })
            }
