    public class OrganizationRepository : whatever interfaces {
        public void Add (OrganizationDTO newOrg) {
            if (newOrg.Action != "A")    // Why are you here?
               throw an exception (bad request)
    
            context.Organizations.Add(Map DTO to entity here);
            foreach (var item in newOrg.Products) {
                switch (item.Action)
                case "A":
                    ProductRepository.Add(item,newOrg.Id);
                    break;
                case "C":
                    ProductRepository.Update(item,newOrg.Id);
                    break;
                case "D":
                    ProductRepository.Delete(item);
                    break;
            }
            context.SaveChanges();
        }
        public void Update (OrganizationDTO oldOrg) {
            if (newOrg.Action != "C")    // Why are you here?
               throw an exception (bad request)
    
            context.Organizations.Attach(Map DTO to entity here);
            foreach (var item in newOrg.Products) {
                switch (item.Action)
                case "A":
                    ProductRepository.Add(item,newOrg.Id);
                    break;
                case "C":
                    ProductRepository.Update(item,newOrg.Id);
                    break;
                case "D":
                    ProductRepository.Delete(item);
                    break;
            }
            context.SaveChanges();
            return Ok();
        }
    }
