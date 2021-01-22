    var prop = @event.Proposals.Aggregate(
               new List<EventProposal>(), 
               (list, proposal) => { list.AddRange(proposal.Services
                                                   .Where(service =>
                                                    !string.IsNullOrEmpty(service.LongDescription)));                                      
                                     return list;
                                    }
                );
