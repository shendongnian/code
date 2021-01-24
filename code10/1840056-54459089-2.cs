        class PartnerComparer : IEqualityComparer<AE_AlignedPartners>
        {
            // Partners are equal if their ObjectID's are equal.
            public bool Equals(AE_AlignedPartners x, AE_AlignedPartners y)
            {         
                //Check whether the partner's ObjectID's are equal.
                return x.ObjectID == y.ObjectID;
            }
            public int GetHashCode(AE_AlignedPartners ap) {
                return ap.ObjectId.GetHashCode();
            }
        }
            
       var intersect = ae_alignedPartners_news.Intersect(ae_alignedPartners_olds);
       var creates = ae_alignedPartners_news.Except(intersect, new PartnerComparer);
       var deletes = ae_alignedPartners_old.Except(intersect, new PartnerComparer);
            
