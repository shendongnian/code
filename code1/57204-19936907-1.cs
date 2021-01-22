            string path = @"d:\temp.xml";
            xmlDoc.Save(path);
    
            XElement xml = XElement.Load(path);
    
            //Search Type Question
            var qryTipoChecklist = from p in xml.Elements("tipo_checklist")
                                   where p.Attribute("id").Value == "7"
                                   select p;
    
            Assert.AreEqual(qryTipoChecklist.Count(), 1);
    
            //Search Group Question
            var qryGrupoQuestao = from tpChecklist in xml.Elements("tipo_checklist")
                                  from gQuest in tpChecklist.Elements("grupo_questao")
                                  where gQuest.Attribute("id").Value == "27"
                                  select gQuest;
    
            Assert.AreEqual(qryGrupoQuestao.Count(), 1);
    
    
            //Search Question
            var qryQuestao = from tpChecklist in xml.Elements("tipo_checklist")
                             from gQuestao in tpChecklist.Elements("grupo_questao")
                             from questao in gQuestao.Elements("questao")
                             where questao.Attribute("id").Value == "253"
                             select questao;
    
            Assert.AreEqual(qryQuestao.Count(), 1);
