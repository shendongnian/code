    class Partner
    {
        public int codPartner {get; set;}
        public string name {get; set;}
        public override int GetHashCode() { return name .GetHashCode();}
    }
    
    var x = _partnerService.SelectPartners()
            .Select(c => new Partner {codPartner = c.codPartner, name = c.name})
            .Distinct();
