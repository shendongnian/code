    lESResponse = lESClient.Search<PropertyDTO>(s => s
                        .Query(q => q
                            .Nested(n => n
                                .Path("publications")
                                .Query(qu => qu
                                    .Bool(b => b
                                        .Must(new QueryContainer[] {
                                            new DateRangeQuery() {
                                                Field = "publications.publishedOn",
                                                GreaterThanOrEqualTo = DateMath.Anchored(DateTime.MinValue),
                                                LessThanOrEqualTo = DateMath.Anchored(DateTime.Now)
                                            },
                                            new TermQuery() {
                                                Field = "publications.id",
                                                Value = "1.510136"
                                            }
                                        } ))))));
