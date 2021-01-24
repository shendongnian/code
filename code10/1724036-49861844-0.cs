    if (codOccu > 0)
                {
                    ocorrencias = db.CRM_OCORRENCIAS.Where(o => o.ID_OCORRENCIA == codOccu)
                              .OrderByDescending(o => o.ID_OCORRENCIA);
                }
    
                if (nomeEmp.Length > 0)
                {
                    ocorrencias = ocorrencias.Where(o => o.CLIENTES.NOMEFAN.Contains(nomeEmp) || o.CLIENTES.NOMERAZAO.Contains(nomeEmp))
                               .OrderByDescending(o => o.ID_OCORRENCIA);
                }
    
                if (dtAbert != null && dtFinal != null)
                {
                    ocorrencias = ocorrencias.Where(o => o.DTABERTURA >= dtAbert && o.DTABERTURA <= dtFinal)
                              .OrderByDescending(o => o.ID_OCORRENCIA);
                    _dataIni = Convert.ToDateTime(dtAbert).ToString("yyyy-MM-dd");
                    _dataFim = Convert.ToDateTime(dtFinal).ToString("yyyy-MM-dd");
                }
    
                //   
                if (codOccu == 0 && nomeEmp == "" && dtAbert == null && dtFinal == null)
                    ocorrencias = db.CRM_OCORRENCIAS;
                   
                return return View(ocorrencias.OrderByDescending(o => o.ID_OCORRENCIA).ToPagedList(pagina, 40));
