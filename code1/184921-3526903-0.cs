    class EntityObjectComparer : IEqualityComparer<EntityObject>
    {
        public bool Equals(EntityObject x, EntityObject y)
        {
            string xId = GetBondIdentifier(x);
            string yId = GetBondIdentifier(y);
    
            return x.Equals(y);
        }
    
        private string GetBondIdentifier(EntityObject obj)
        {
            var sm = obj as SecurityMaster;
            if (sm != null)
            {
                return sm.BondIdentifier;
            }
    
            var sms = obj as SecurityMasterSchedules;
            if (sms != null)
            {
                return sms.BondIdentifier;
            }
    
            return string.Empty;
        }
    }
    List<EntityObject> list1 = GetList1();
    List<EntityObject> list2 = GetList2();
    
    var itemsInList1NotInList2 = list1.Except(list2, new EntityObjectComparer());
