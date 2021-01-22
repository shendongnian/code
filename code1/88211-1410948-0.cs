    public class Prop
    {
        Resource _res;
        public Prop(Resource res)
        {
            this._res = res;
        }
        public string Value
        {
            get
            {
                return LocaleHelper.GetRessource(_res);
            }
            set
            {
                if(_res == null)
                    // This is a weak point as it's now
                    // as it wont work
                else
                    _res.DefaultValue = value;
            }
    }
