    public static void Main(string[] args)
            {
                List<Section> sections = new List<Section>();
                List<ContractTerm> contractTerms = new List<ContractTerm>();
                List<TermItem> termItens = new List<TermItem>();
    
    
                var result = (from contractTerm in contractTerms
                              join termItem in termItens
                                  on new
                                  {
                                      contractTerm.SectionId,
                                      contractTerm.SubsectionId,
                                      contractTerm.TermId
                                  }
                                  equals new
                                  {
                                      termItem.SectionId,
                                      termItem.SubsectionId,
                                      termItem.TermId
                                  } 
                              join section in sections
                               on new
                               {
                                   contractTerm.SectionId,
                                   contractTerm.SubsectionId
                               } equals new
                               {
                                   section.SectionId,
                                   section.SubsectionId
                               } 
                              select
                              new {
                                 sectionName = section.Name,
                                 termItemText = termItem.Text
                              }).ToList();
    
                foreach(var it in result)
                {
                    Console.WriteLine(it.sectionName);
                    Console.WriteLine(it.termItemText);
                }
            }
