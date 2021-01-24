    var result = elasticClient.UpdateByQuery<ProductType>(u => u
                      .Query(q => q
                            .Nested(n => n
                              .Path(Infer.Field<ProductType>(ff => ff.ProductAttributes))
                              .Query(nq => nq
                                  .Term(Infer.Field<ProductType>(ff => ff.ProductAttributes.First().Id), productAttributeId)
                              )
                            )
                      )
                      .Script(ss => ss.Inline("if (ctx._source.productAttributes != null){for (item in ctx._source.productAttributes){if (item.id == params.id) {item.name = params.name;}}}")
                         .Params(new Dictionary<string, object>()
                         {
                             {"id", productAttributeId},
                             {"name", productAttributeName}
                         }).Lang("painless")
                      )
                      .Conflicts(Conflicts.Proceed)
                      .Refresh(true)
                  );
