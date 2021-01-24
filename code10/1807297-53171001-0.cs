    var nomesDeInformacoes = db.InformacoesComplementaresDaEmpresa.Where(a => a.idempresa == idDaEmpresaNoFormatocerto)
                                                                          .Join(db.InformacoesComplementaresDoLayout,
                                                                                ice => ice.idinformacao ,
                                                                                icl => icl.idinformacao ,
                                                                                (ice, icl) =>  new { ice, icl } )
                                                                          .Select(
                                                                          //creating a class to accept the fields i want  
                                                                          })
                                                                          .ToList();
      
