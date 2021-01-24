    public class DTOBase
    {
        public DTOBase() { }
        public DTOBase(Object Entity)
        {
            if (Entity == null) return;
            Type tObjFrom = Entity.GetType();
            Type tObjTo = this.GetType();
            var listPropObj1 = tObjFrom.GetProperties().Where(p => p.GetValue(Entity) != null).ToList();
            foreach (var item in listPropObj1)
            {
                if (tObjTo.GetProperty(item.Name) != null)
                {
                    tObjTo.GetProperty(item.Name).SetValue(this, item.GetValue(Entity));
                }
            }
        }
        public void MapToEntity(object Entity)
        {
            if (Entity == null) return;
            Type tObjTo = Entity.GetType();
            Type tObjFrom = this.GetType();
            var listPropObj1 = tObjFrom.GetProperties().ToList();
            foreach (var item in listPropObj1)
            {
                if (tObjTo.GetProperty(item.Name) != null)
                {
                    //if (item.GetValue(this) != null)
                    tObjTo.GetProperty(item.Name).SetValue(Entity, item.GetValue(this));
                }
            }
        }
    }
 
