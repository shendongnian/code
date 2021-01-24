    public void OnGet(int id, string tab)
    
            {     //for Footwere
               var Footw = _Context.Footwere.Where(p=>p.ProductID==id).FirstOrDefault() ;
               _Context.Footwere.Add(Footw);
              _Context.SaveChanges();
            }
