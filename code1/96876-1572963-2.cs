        public partial class Audit
        {
            // ...
            public Audit Concrete()
            {
                if (this.GetType().Equals(typeof(Audit)))
                    return this;
                else
                {
                    Audit audit = new Audit();
                    // clone properties
                    return audit;
                }
            }
        }
    //...
    dataContext.Audits.InsertOnSubmit(audit.Concrete());
