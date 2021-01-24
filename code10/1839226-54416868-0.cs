     public static decimal total(ResourceTier rt, List<ResourceTier> data)
        {
            if (data.Where(x=>x.ParentId==rt.Id).Count()==0)
            return rt.Volume*rt.UnitRate;
            else
            {
              var sum=  data.Where(x => x.ParentId == rt.Id).Select(x=>total( x,data)).Sum();
                return rt.UnitRate*rt.Volume+sum;
            }
        }
