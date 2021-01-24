    public ChangeNet Update(ChangeNetEditViewModelBase modelBase) {
    try {
            var items = _context.ChangeNets.Include(x => x.ProductOffers.Select(p=>p.ProductOffer));
            var changeNet = items.FirstOrDefault(o => o.Id == modelBase.Id);
            if (changeNet == null) return null;
            
            Mapper.Map(modelBase, changeNet); //IT COPIES NESTED PROPS IN WRONG WAY!!!
            changeNet.name = "test";
            changeNet.ProductOffers = modelBase.ProductOffers; //ASSIGN DIRECTLY!!!
            _context.SaveChanges();        
            return changeNet;
        }
        catch (Exception exception) {
            _logger.Error(exception); 
            return null;
        }
    }
